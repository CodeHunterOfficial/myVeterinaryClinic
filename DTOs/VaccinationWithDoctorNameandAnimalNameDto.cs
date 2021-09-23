using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.DTO.Vaccination
{
    public class VaccinationWithDoctorNameandAnimalNameDto
    {
        public int VaccinationId { get; set; }
        public string AnimalName { get; set; }
        public string DoctorName { get; set; }
        public string VaccinationName { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateVaccination { get; set; }
        public DateTime? NextDateVaccination { get; set; }

    }
}
