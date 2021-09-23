using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Repository
{
    public class VaccinationRepository : IVaccinationRepository
    {
        private readonly VeterinaryClinicContext _context;
        private readonly ILogger _logger;
        public VaccinationRepository(VeterinaryClinicContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<Vaccination> AddVaccination(Vaccination vaccinationforAdd)
        {
            Vaccination vaccination = new Vaccination()
            {
                Name = vaccinationforAdd.Name,
                Price = vaccinationforAdd.Price,
                DoctorId = vaccinationforAdd.DoctorId,
                AnimalId = vaccinationforAdd.AnimalId,
                DateVaccination = vaccinationforAdd.DateVaccination,
                NextDateVaccination = vaccinationforAdd.NextDateVaccination
            };
            try
            {
                _context.Vaccinations.Add(vaccination);
                await _context.SaveChangesAsync();
                _logger.Info("Start: Add Vaccination:");
                return vaccination;
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Add Vaccination is Failed: " + exp.Message);
                return null;
            }
        }

        public async Task DeleteVaccination(int vaccinationIdforDelete)
        {
            try
            {
                var vaccinationforDelete = GetVaccinationById(vaccinationIdforDelete);
                _context.Vaccinations.Remove(vaccinationforDelete);
                await _context.SaveChangesAsync();
                _logger.Info($"Start: Delete Vaccination by Id:{0}" , vaccinationIdforDelete);
            }
            catch (Exception exp)
            {
                _logger.Error($"Start: Delete Vaccinationn by ID:{0} is Failed: {1} ",vaccinationIdforDelete, exp.Message);
            }
        }

        public Vaccination GetVaccinationById(int vaccinationIdforGet)
        {
            try
            {
                var result = (_context.Vaccinations.FirstOrDefault(x => x.VaccinationId == vaccinationIdforGet));
                _logger.Info("Start: Get Vacccination By ID:{0} is Completed:", vaccinationIdforGet);
                return result;
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Get Vacccination By ID:{0} is Failed: {1}", vaccinationIdforGet, exp.Message);
                return null;
            }
        }

        public async Task<IList<Vaccination>> GetVaccinations()
        {
            try
            {
                _logger.Info("Start: Get List Of Vacccination is Completed: ");
                return await _context.Vaccinations.ToListAsync();
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Get List Of Vacccination is Failed: " + exp.Message);
                return null;
            }
        }
        public async Task UpdateVaccination(Vaccination vaccinationforUpdate)
        {
            try
            {
                _context.Entry(vaccinationforUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.Info("Start: Update Vacccination is Completed: ");
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Update Vacccination is Failed: " + exp.Message);
            }
        }
    }
}
