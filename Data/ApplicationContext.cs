using HospitalServices.PatientService.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HospitalServices.PatientService.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Patient> Patient { get; set; }
    }
}
