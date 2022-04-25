using HospitalServices.PatientService.Data;
using HospitalServices.PatientService.Models.Domain;
using HospitalServices.PatientService.Models.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalServices.PatientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        //Dependency injection, drar in applicationContext så att vi kan använda oss av det.
        //Så att vi kan använda context i vår actionresult nedan.
        private ApplicationContext Context { get; }

        public PatientsController(ApplicationContext context)
        {
            Context = context;
        }

        [HttpPost]
        public IActionResult RegisterPatient(PatientDto patientDto)
        {
            var patient = new Patient(
                firstName: patientDto.FirstName,
                lastName: patientDto.LastName,
                socialSecurityNumber: patientDto.SocialSecurityNumber,
                phoneNumber: patientDto.PhoneNumber
           );

            Context.Patient.Add(patient);

            Context.SaveChanges();

            return Created("", patientDto); // svarar 201 created, skickar ut patientDto så alltså exakt samma som skickas in.
        }

        [HttpGet("{socialSecurityNumber}")] // specificerar att vi har sosnr som kommer in som en del av uri:n (Uniform Resource Identifier)
        public IActionResult GetPatient(string socialSecurityNumber) 
        {
            var patient = Context.Patient.FirstOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);

            if (patient == null)
            {
                return NotFound(); // 404 not found
            }

            var patientDto = new PatientDto
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                SocialSecurityNumber = socialSecurityNumber,
                PhoneNumber = patient.PhoneNumber
            };

            return Ok(patientDto); // 200 OK

        }
    }
}
