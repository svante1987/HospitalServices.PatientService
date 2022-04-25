using System.ComponentModel.DataAnnotations;

namespace HospitalServices.PatientService.Models.Domain
{
    public class Patient
    {
        public Patient(string firstName, string lastName, string socialSecurityNumber, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            PhoneNumber = phoneNumber;
        }

        // protected så att man inte kan sätta den externt
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        [Key]
        public string SocialSecurityNumber { get; protected set; }
        public string PhoneNumber { get; protected set; }
    }
}
