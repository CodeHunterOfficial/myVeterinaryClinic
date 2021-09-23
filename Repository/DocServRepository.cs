using Microsoft.EntityFrameworkCore;
using myVeterinaryClinic.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.Models;

namespace myVeterinaryClinic.Repository
{
    public class DocServRepository : IDocServRepository
    {
        private readonly VeterinaryClinicContext _context;
        private readonly ILogger _logger;

        public DocServRepository(VeterinaryClinicContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<DocServ> AddDocServ(DocServ docServForAdd)
        {
            DocServ docServ = new DocServ()
            {
                doctorID = docServForAdd.doctorID,
                serviceID = docServForAdd.serviceID
            };
            try
            {
                _context.DocServs.Add(docServ);
                await _context.SaveChangesAsync();
                _logger.Info("Start: Added DocServ ");
                return docServ;
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Added DocServ is Failed: " + exp.Message);
                return null;
            }
        }

        public async Task DeleteDocServ(int docServIdForDelete)
        {
            try
            {
                var docServForDelete = GetDocServById(docServIdForDelete);
                _context.DocServs.Remove(docServForDelete);
                await _context.SaveChangesAsync();
                _logger.Info("Start: Deleted DocServ ");
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Added DocServ is Failed: " + exp.Message);
            }
        }

        public async Task<IList<DocServ>> GetDocServs()
        {
            try
            {
                _logger.Info("Start: Get List of DocServs ");
                return await _context.DocServs.ToListAsync();
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Added DocServ is Failed: " + exp.Message);
                return null;
            }
        }

        public DocServ GetDocServById(int docServIdForGet)
        {
            try
            {
                var result = (_context.DocServs.FirstOrDefault(x => x.DocServID == docServIdForGet));
                _logger.Info("Start: Get DocServ By ID ");
                return result;
            }
            catch (Exception exp)
            {
                _logger.Error($"Start: Get DocServ By ID:{0} is Failed: {1}", docServIdForGet, exp.Message);
                return null;
            }
        }

        public async Task<IList<Doctor>> GetListOfDoctors(int serviceId)
        {
            try
            {
                var sql = (from ds in _context.DocServs
                           join doc in _context.Doctors on ds.doctorID equals doc.DoctorId
                           where ds.serviceID.Equals(serviceId)
                           select new Doctor
                           {
                               DoctorId = doc.DoctorId,
                               FullName = doc.FullName,
                               Phone = doc.Phone,
                               Gender = doc.Gender
                           }).ToListAsync();
                _logger.Info("Start: Get List of DocServs By ServiceID ");
                return await sql;
            }
            catch (Exception exp)
            {
                _logger.Error($"Start: Get List of DocServs By ServiceID: {0} is Failed: ", serviceId + exp.Message);
                return null;
            }
        }

        public async Task<IList<Service>> GetListOfService(int doctorId)
        {
            try
            {
                var sql = (from ds in _context.DocServs
                           join serv in _context.Services on ds.serviceID equals serv.ServiceId
                           where ds.doctorID.Equals(doctorId)
                           select new Service
                           {
                               ServiceId = serv.ServiceId,
                               Name = serv.Name,
                               Price = serv.Price
                           }).ToListAsync();
                _logger.Info("Start: Get List of Servers By doctorID ");
                return await sql;
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Get List of Servers By doctorID is Failed: " + exp.Message);
                return null;
            }
        }
        public async Task UpdateDocServ(DocServ docServforUpdate)
        {
            try
            {
                _context.Entry(docServforUpdate).State = EntityState.Modified;
                _logger.Info("Start: UpdateDocServ");
                await _context.SaveChangesAsync();
            }
            catch (Exception exp)
            {
                _logger.Error("Start: UpdateDocServis Failed: " + exp.Message);
            }
        }
    }
}
