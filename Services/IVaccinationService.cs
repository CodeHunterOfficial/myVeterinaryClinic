using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
namespace VeterinaryClinic.Services
{
    public interface IVaccinationService
    {
        public Task<IList<VaccinationDto>> GetVaccinations();
        public Task<VaccinationDto> AddVaccination(VaccinationDto vaccinationforAdd);
        public Task UpdateVaccination(VaccinationDto vaccinationforUpdate);
        public Task DeleteVaccination(int vaccinationIdforDelete);
        public Task<VaccinationDto> GetVaccinationById(int vaccinationIdforGet);
    }
}
