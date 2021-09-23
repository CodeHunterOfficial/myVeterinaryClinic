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
    public class DoctorsController : ControllerBase
    {
        private readonly VeterinaryClinicContext _context;
        private readonly IDoctorService _doctorService;
        private readonly ILogger _logger;
        public DoctorsController(VeterinaryClinicContext context,
                                 IDoctorService doctorService)
        {
            _context = context;
            _doctorService = doctorService;
            _logger = LogManager.GetCurrentClassLogger();
        }
        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            var doctors = await _doctorService.GetDoctors();
            if (doctors == null)
            {
                _logger.Error("DoctorsController: Get List Of Doctors is Failed");
                return NotFound();
            }
            _logger.Info("DoctorsController: Get List Of Doctors is Completed");
            return Ok(doctors);
        }

        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public ActionResult<DoctorDto> GetDoctor(int id)
        {
            var doctor = _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                _logger.Error("DoctorsController: Get Doctor by ID is Failed");
                return NotFound();
            }
            _logger.Info("DoctorsController: Get Doctor by ID is Completed");
            return Ok(doctor);
        }
        // PUT: api/Doctors/5 
        [HttpPut("{id}")]
        public IActionResult PutDoctor(DoctorDto updateDoctorDto)
        {
            try
            {
                _doctorService.UpdateDoctor(updateDoctorDto);
                _logger.Info("DoctorsController: Put Doctor is Completed");
                return Ok();
            }
            catch (Exception)
            {
                _logger.Error("DoctorsController: Put Doctor is Failed");
                return NotFound();
            }
        }
        // POST: api/Doctors       
        [HttpPost]
        public ActionResult<DoctorDto> PostDoctor(DoctorDto AddDoctorDto)
        {
            try
            {
                _doctorService.AddDoctor(AddDoctorDto);
                _logger.Info("DoctorsController: Post Doctor is Completed");
                return Ok();
            }
            catch (Exception)
            {
                _logger.Error("DoctorsController: Post Doctor is Failed");
                return BadRequest();
            }
        }
        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public ActionResult<DoctorDto> DeleteDoctor(int id)
        {
            try
            {
                _doctorService.DeleteDoctor(id);
                _logger.Info("DoctorsController: Delete Doctor is Completed");
                return Ok();
            }
            catch (Exception)
            {
                _logger.Error("DoctorsController: Delete Doctor is Failed");
                return NotFound();
            }
        }
    }
}

