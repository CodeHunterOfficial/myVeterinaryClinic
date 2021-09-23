using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myVeterinaryClinic.DTOs;
using myVeterinaryClinic.Services;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;

namespace myVeterinaryClinic.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DocServController : ControllerBase
    {
        private readonly VeterinaryClinicContext _context;
        private readonly IDocServService _docServService;
        private readonly ILogger _logger;
        public DocServController(VeterinaryClinicContext context,
                                 IDocServService docServService)
        {
            _context = context;
            _docServService = docServService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        // GET: /api/v1/DocServ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocServDto>>> GetDoctorsAndServices()
        {
            var docserv = await _docServService.GetDocServs();
            if (docserv == null)
            {
                _logger.Error("DocServ: Get DocServ is Failed ");
                return NotFound();
            }
            _logger.Info("DocServ: Get DocServ is Completed ");
            return Ok(docserv);
        }

        // GET: api/api/v1/DocServ/1
        [HttpGet("{id}")]
        public ActionResult<DocServDto> GetDoctorsAndServicesByID(int id)
        {
            var docserv = _docServService.GetDocServById(id);
            if (docserv == null)
            {
                _logger.Error("DocServ: Get DocServ by ID is Failed ");
                return NotFound();
            }
            _logger.Info("DocServ: Get DocServ by ID is Completed ");
            return Ok(docserv);
        }

        // GET: api/api/v1/DocServ/1
        [HttpGet()]
        [Route("~/api/v1/listofdoctors/")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetListOfDoctors(int serviceId)
        {
            var doctors = await _docServService.GetListOfDoctors(serviceId);
            if (doctors == null)
            {
                _logger.Error("DocServ: Get list Of Doctors is Failed ");
                return NotFound();
            }
            _logger.Info("DocServ: Get list Of Doctors is Completed ");
            return Ok(doctors);
        }
        // GET: api/api/v1/DocServ/1
        [HttpGet()]
        [Route("~/api/v1/listofservices/")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetListOfServices(int doctorId)
        {
            var services = await _docServService.GetListOfService(doctorId);
            if (services == null)
            {
                _logger.Error("DocServ: Get list Of Services is Failed ");
                return NotFound();
            }
            _logger.Info("DocServ: Get list Of Services is Completed ");
            return Ok(services);
        }

        // PUT: api/api/v1/DocServ/1
        [HttpPut("{id}")]
        public IActionResult PutDoctorAndService(DocServDto updatedocserv)
        {
            try
            {
                _docServService.UpdateDocServ(updatedocserv);
                _logger.Info("DocServ: Put DocServ is Completed ");
                return Ok();
            }
            catch (Exception)
            {
                _logger.Error("DocServ: Put DocServ is Failed ");
                return BadRequest();
            }
        }
        // POST: api/api/v1/DocServ    
        [HttpPost]
        public ActionResult<AnimalDto> PostDoctorAndService(DocServDto adddocserv)
        {
            try
            {
                _docServService.AddDocServ(adddocserv);
                _logger.Info("DocServ: Post DocServ is Completed ");

                return Ok();
            }
            catch (Exception)
            {
                _logger.Error("DocServ: Post DocServ is Failed ");
                return BadRequest();
            }
        }
        // DELETE: api/api/v1/DocServ/1
        [HttpDelete("{id}")]
        public ActionResult<DocServDto> DeleteDoctorAndService(int id)
        {
            try
            {
                _docServService.DeleteDocServ(id);
                _logger.Info("DocServ: Delete DocServ is Completed ");
                return Ok();
            }
            catch (Exception)
            {
                _logger.Error("DocServ: Delete DocServ is Failed ");
                return NotFound();
            }
        }
    }
}
