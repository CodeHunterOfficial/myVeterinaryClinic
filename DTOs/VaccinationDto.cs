using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinaryClinic.DTOs
{
    public class VaccinationDto
    {
        public int VaccinationId { get; set; }
        public int? AnimalId { get; set; }
        public int? DoctorId { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateVaccination { get; set; }
        public DateTime? NextDateVaccination { get; set; }
    }
}
