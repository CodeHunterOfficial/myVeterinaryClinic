using System;
namespace VeterinaryClinic.Models
{
    public partial class Vaccination
    {
        public int VaccinationId { get; set; }
        public int? AnimalId { get; set; }
        public int? DoctorId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateVaccination { get; set; }
        public DateTime? NextDateVaccination { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
