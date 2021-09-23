using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly VeterinaryClinicContext _context;
        private readonly ILogger _logger;
        public OwnerRepository(VeterinaryClinicContext context)
        {
            _logger = LogManager.GetCurrentClassLogger();
            _context = context;
        }

        public async Task<IList<Owner>> GetOwners()
        {
            try
            {
                _logger.Info("Start: Get List of Owners");
                return await _context.Owners.ToListAsync();
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Get List of Owners is Failed: " + exp.Message);
                return null;
            }
        }

        public async Task<Owner> AddOwner(Owner ownerForAdd)
        {
            Owner newowner = new Owner();
            newowner.FullName = ownerForAdd.FullName;
            newowner.Gender = ownerForAdd.Gender;
            newowner.Phone = ownerForAdd.Phone;
            newowner.OwnerId = ownerForAdd.OwnerId;
            try
            {
                _context.Owners.Add(newowner);
                await _context.SaveChangesAsync();
                _logger.Info("Start: Add Owner");
                return newowner;
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Get List of Owners is Failed: " + exp.Message);
                return null;
            }
        }
        public async Task DeleteOwner(int ownerIdForDelete)
        {
            try
            {
                var ownerToDelete = GetOwnerById(ownerIdForDelete);
                _context.Owners.Remove(ownerToDelete);
                await _context.SaveChangesAsync();
                _logger.Info($"Start: Delete Owner by ID: {0}" , ownerIdForDelete);
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Get List of Owners is Failed: " + exp.Message);
            }
        }
        public async Task UpdateOwner(Owner ownerForUpdate)
        {
            try
            {

                _context.Entry(ownerForUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.Info("Start: Update Owner");
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Get List of Owners is Failed: " + exp.Message);
            }
        }
        public Owner GetOwnerById(int ownerIdForGet)
        {
            try
            {
                var result = (_context.Owners.FirstOrDefault(x => x.OwnerId == ownerIdForGet));
                _logger.Info($"Start: Get Owner by ID:{0}", ownerIdForGet);
                return result;
            }
            catch (Exception exp)
            {
                _logger.Error($"Start: Get Owner by ID: {0} is Failed: {1} " , ownerIdForGet,exp.Message);
                return null;
            }
        }
    }
}
