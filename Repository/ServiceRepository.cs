using Microsoft.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly VeterinaryClinicContext _context;
        private readonly ILogger _logger;
        public ServiceRepository(VeterinaryClinicContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<Service> AddService(Service serviceforAdd)
        {
            Service service = new Service()
            {
                Name = serviceforAdd.Name,
                Price = serviceforAdd.Price
            };
            try
            {
                _context.Services.Add(service);
                await _context.SaveChangesAsync();
                _logger.Info("Start: Add  Service");
                return service;
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Add service is Failed: " + exp.Message);
                return null;
            }
        }

        public async Task DeleteService(int serviceId)
        {
            try
            {
                var serviceToDelete = GetServiceById(serviceId);
                _context.Services.Remove(serviceToDelete);
                await _context.SaveChangesAsync();
                _logger.Info("Start: Delete  Service");
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Add service is Failed: " + exp.Message);
            }
        }

        public Service GetServiceById(int serviceId)
        {
            try
            {
                var result = (_context.Services.FirstOrDefault(x => x.ServiceId == serviceId));
                _logger.Info("Start: Get Service by ID:" + serviceId.ToString());
                return result;
            }
            catch (Exception exp)
            {
                _logger.Error("Start:Get Service by ID is Failed: " + exp.Message);
                return null;
            }
        }

        public async Task<IList<Service>> GetServices()
        {
            try
            {
                _logger.Info("Start: Get List Of Services");
                return await _context.Services.ToListAsync();
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Get List Of Services is Failed: " + exp.Message);
                return null;
            }
        }

        public async Task UpdateService(Service serviceforUpdate)
        {
            try
            {
                _context.Entry(serviceforUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.Info("Start: Update Services");
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Update Services is Failed: " + exp.Message);
            }
        }
    }
}
