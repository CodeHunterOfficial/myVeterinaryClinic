using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.Models;
namespace VeterinaryClinic.Repository
{
    public interface IVaccinationRepository
    {
        public Task<IList<Vaccination>> GetVaccinations();
        public Task<Vaccination> AddVaccination(Vaccination vaccinationforAdd);
        public Task UpdateVaccination(Vaccination vaccinationforUpdate);
        public Task DeleteVaccination(int vaccinationIdforDelete);
        public Vaccination GetVaccinationById(int vaccinationIdforGet);
    }
}
