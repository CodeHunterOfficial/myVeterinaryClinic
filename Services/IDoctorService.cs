using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
namespace VeterinaryClinic.Services
{
    public interface IDoctorService
    {
        public Task<IList<DoctorDto>> GetDoctors();
        public Task<DoctorDto> AddDoctor(DoctorDto doctorForAdd);
        public Task UpdateDoctor(DoctorDto doctorForUpdate);
        public Task DeleteDoctor(int doctorIdForDelete);
        public Task<DoctorDto> GetDoctorById(int doctorIdForGet);
    }
}
