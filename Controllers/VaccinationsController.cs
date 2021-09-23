using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
using VeterinaryClinic.Services;

namespace VeterinaryClinic.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VaccinationsController : ControllerBase
    {
        private readonly VeterinaryClinicContext _context;
        private readonly IVaccinationService _vaccinationService;
        private readonly ILogger _logger;

        public VaccinationsController(VeterinaryClinicContext context,
                                 IVaccinationService animalService)
        {
            _context = context;
            _vaccinationService = animalService;
            _logger = LogManager.GetCurrentClassLogger();
        }
        // GET: api/Vaccinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationDto>>> GetVaccinations()
        {
            var animas = await _vaccinationService.GetVaccinations();
            if (animas == null)
            {
                _logger.Error("VaccinationsController: Get List Of Vaccinations is Failed ");
                return NotFound();
            }
            _logger.Info("VaccinationsController: Get List Of Vaccinations is Completed ");
            return Ok(animas);
        }

        // GET: api/Vaccinations/5
        [HttpGet("{id}")]

        public ActionResult<VaccinationDto> GetVaccination(int id)
        {
            var animas = _vaccinationService.GetVaccinationById(id);
            if (animas == null)
            {
                _logger.Error("VaccinationsController: Get Vaccination by ID is Failed ");
                return NotFound();
            }
            _logger.Info("VaccinationsController: Get Vaccination by ID is Completed ");
            return Ok(animas);
        }
        // PUT: api/Vaccinations/5 
        [HttpPut("{id}")]
        public IActionResult PutVaccination(VaccinationDto updateVaccinationDto)
        {
            try
            {
                _vaccinationService.UpdateVaccination(updateVaccinationDto);
                _logger.Info("VaccinationsController: Put Vaccination  is Completed ");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("VaccinationsController: Put Vaccination  is Completed " + exp.Message);
                return NotFound();
            }
        }
        // POST: api/Vaccinations       
        [HttpPost]
        public ActionResult<VaccinationDto> PostVaccination(VaccinationDto AddVaccinationDto)
        {
            try
            {
                _vaccinationService.AddVaccination(AddVaccinationDto);
                _logger.Info("VaccinationsController: Post Vaccination  is Completed ");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("VaccinationsController: Post Vaccination  is Completed " + exp.Message);
                return NotFound();
            }
        }
        // DELETE: api/Vaccinations/5
        [HttpDelete("{id}")]
        public ActionResult<VaccinationDto> DeleteVaccination(int id)
        {
            try
            {
                _vaccinationService.DeleteVaccination(id);
                _logger.Info("VaccinationsController: Delete Vaccination  is Completed ");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("VaccinationsController: Delete Vaccination  is Completed " + exp.Message);
                return BadRequest();
            }
        }
    }
}
