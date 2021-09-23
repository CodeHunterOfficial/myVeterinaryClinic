using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly VeterinaryClinicContext _context;
        private readonly ILogger _logger;
        public DoctorRepository(VeterinaryClinicContext context)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _context = context;
        }
        public async Task<IList<Doctor>> GetDoctors()
        {
            try
            {

                _logger.Info("Start: Get List Of Doctors");
                return await _context.Doctors.ToListAsync();
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Added animal is Failed: " + exp.Message);
                return null;
            }
        }
        public async Task<Doctor> AddDoctor(Doctor doctorforAdd)
        {
            try
            {
                Doctor doctor = new Doctor
                {
                    FullName = doctorforAdd.FullName,
                    Gender = doctorforAdd.Gender,
                    Phone = doctorforAdd.Phone
                };

                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
                _logger.Info("Start: Add new Doctor");
                return doctor;
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Add new Doctor is Failed: " + exp.Message);
                return null;
            }
        }

        public async Task UpdateDoctor(Doctor doctorForUpdate)
        {
            try
            {
                _context.Entry(doctorForUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.Info("Start: Update Doctor");
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Update Doctor is Failed: " + exp.Message);
            }
        }

        public async Task DeleteDoctor(int doctorIdForDelete)
        {
            try
            {
                var doctorToDelete = GetDoctorById(doctorIdForDelete);
                _context.Doctors.Remove(doctorToDelete);
                await _context.SaveChangesAsync();
                _logger.Info($"Start: Delete Doctor by ID:{0}", doctorIdForDelete);
            }
            catch (Exception exp)
            {
                _logger.Error($"Start: Delete Doctor by ID: {0} is Failed: ", doctorIdForDelete + exp.Message);
            }
        }

        public Doctor GetDoctorById(int doctorId)
        {
            try
            {
                Doctor result = _context.Doctors.FirstOrDefault(x => x.DoctorId == doctorId);
                _logger.Info($"Start:Get Doctor by ID: {0}", doctorId);
                return result;
            }
            catch (Exception exp)
            {
                _logger.Error($"Start: Get Doctor by ID:{0} is Failed: ", doctorId + exp.Message);
                return null;
            }
        }
    }
}
