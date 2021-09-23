using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.Models;
namespace VeterinaryClinic.Repository
{
    public interface IDoctorRepository
    {
        public Task<IList<Doctor>> GetDoctors();
        public Task<Doctor> AddDoctor(Doctor doctorForAdd);
        public Task UpdateDoctor(Doctor doctorForUpdate);
        public Task DeleteDoctor(int doctorIdForDelete);
        public Doctor GetDoctorById(int doctorId);
    }
}
