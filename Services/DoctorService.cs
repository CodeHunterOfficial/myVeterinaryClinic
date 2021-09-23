using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
using VeterinaryClinic.Repository;
namespace VeterinaryClinic.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public async Task<DoctorDto> AddDoctor(DoctorDto doctorForAdd)
        {
            Doctor doctorToAdd = _mapper.Map<Doctor>(doctorForAdd);
            var result = _doctorRepository.AddDoctor(doctorToAdd);
            var res = _mapper.Map<DoctorDto>(result);
            return await Task.FromResult(res);
        }

        public async Task DeleteDoctor(int doctorId)
        {
            await _doctorRepository.DeleteDoctor(doctorId);
        }

        public async Task<DoctorDto> GetDoctorById(int doctorIdForGet)
        {
            var result = _doctorRepository.GetDoctorById(doctorIdForGet);
            var res = _mapper.Map<DoctorDto>(result);
            return await Task.FromResult(res);
        }

        public async Task<IList<DoctorDto>> GetDoctors()
        {
            var doctors = await _doctorRepository.GetDoctors();
            return doctors.Select(x => _mapper.Map<DoctorDto>(x)).ToList();
        }

        public async Task UpdateDoctor(DoctorDto doctor)
        {
            Doctor doctorToUpdate = _mapper.Map<Doctor>(doctor);
            await _doctorRepository.UpdateDoctor(doctorToUpdate);
        }
    }
}
