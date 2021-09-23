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
    public class OwnersController : ControllerBase
    {
        private readonly VeterinaryClinicContext _context;
        private readonly IOwnerService _ownerService;
        private readonly ILogger _logger;
        public OwnersController(VeterinaryClinicContext context,
                                 IOwnerService ownerService)
        {
            _context = context;
            _ownerService = ownerService;
            _logger = LogManager.GetCurrentClassLogger();
        }
        // GET: api/Owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> GetOwners()
        {
            var owners = await _ownerService.GetOwners();
            if (owners == null)
            {
                _logger.Error("OwnersController: Get List Of Owners is Failed");
                return NotFound();
            }
            _logger.Info("OwnersController: Get List Of Owners is Completed");
            return Ok(owners);
        }
        // GET: api/Owners/5
        [HttpGet("{id}")]
        public ActionResult<DoctorDto> GetOwner(int id)
        {
            var owner = _ownerService.GetOwnerById(id);
            if (owner == null)
            {
                _logger.Error("OwnersController: Get Owner by ID is Failed");
                return NotFound();
            }
            _logger.Info("OwnersController: Get Owner by ID is Completed");
            return Ok(owner);
        }
        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public IActionResult PutOwner(OwnerDto updateOwner)
        {
            try
            {

                _ownerService.UpdateOwner(updateOwner);
                _logger.Info("OwnersController: Put Owner is Completed");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("OwnersController: Put Owneris Failed" + exp.Message);
                return NotFound();
            }
        }
        // POST: api/Owners
        [HttpPost]
        public ActionResult<OwnerDto> PostOwner(OwnerDto addOwnerDto)
        {
            try
            {
                _ownerService.AddOwner(addOwnerDto);
                _logger.Info("OwnersController: Post Owner is Completed");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("OwnersController: Post Owneris Failed" + exp.Message);
                return BadRequest();
            }
        }
        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(int id)
        {
            try
            {
                _ownerService.DeleteOwner(id);
                _logger.Info("OwnersController: Delete Owner is Completed");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("OwnersController: Delete Owneris Failed" + exp.Message);
                return BadRequest();
            }
        }
    }
}
