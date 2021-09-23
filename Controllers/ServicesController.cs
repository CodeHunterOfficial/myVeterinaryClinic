using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
using VeterinaryClinic.Services;

namespace VeterinaryClinic.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly VeterinaryClinicContext _context;
        private readonly IServiceService _serviceService;
        private readonly ILogger _logger;

        public ServicesController(VeterinaryClinicContext context,
                                 IServiceService serviceService)
        {
            _context = context;
            _serviceService = serviceService;
            _logger = LogManager.GetCurrentClassLogger();

        }
        // GET: api/v1/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices()
        {
            var animas = await _serviceService.GetServices();
            if (animas == null)
            {
                _logger.Error("ServicesController: Get List Of Services is Failed");
                return NotFound();
            }
            _logger.Info("ServicesController: Get List Of Services is Completed");
            return Ok(animas);
        }

        // GET: api/v1/Services/5
        [HttpGet("{id}")]
        public ActionResult<ServiceDto> GetService(int id)
        {
            var animas = _serviceService.GetServiceById(id);
            if (animas == null)
            {
                _logger.Error("ServicesController: Get Service by ID is Failed");
                return NotFound();
            }
            _logger.Error("ServicesController: Get Service by ID is Completed");
            return Ok(animas);
        }
        // PUT: api/v1/Services/5 
        [HttpPut("{id}")]
        public IActionResult PutService(ServiceDto updateServiceDto)
        {
            try
            {
                _serviceService.UpdateService(updateServiceDto);
                _logger.Info("ServicesController: Put Service  is Completed");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("ServicesController: Put Service  is Failed" + exp.Message);
                return NotFound();
            }
        }
        // POST: api/v1/Services       
        [HttpPost]
        public ActionResult<ServiceDto> PostService(ServiceDto AddServiceDto)
        {
            try
            {
                _serviceService.AddService(AddServiceDto);
                _logger.Info("ServicesController: Post Service  is Completed");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("ServicesController: Post Service  is Failed" + exp.Message);
                return NotFound();
            }
        }
        // DELETE: api/v1/Services/5
        [HttpDelete("{id}")]
        public ActionResult<ServiceDto> DeleteService(int id)
        {
            try
            {
                _serviceService.DeleteService(id);
                _logger.Info("ServicesController: Delete Service  is Completed");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("ServicesController: Delete Service  is Failed" + exp.Message);
                return BadRequest();
            }
        }
    }
}
