using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
using VeterinaryClinic.Services;

namespace VeterinaryClinic.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly VeterinaryClinicContext _context;
        private readonly IAnimalService _animalService;
        private readonly ILogger _logger;
        public AnimalsController(VeterinaryClinicContext context,
                                 IAnimalService animalService)
        {
            _context = context;
            _animalService = animalService;
            _logger = LogManager.GetCurrentClassLogger();
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimals()
        {
            var animas = await _animalService.GetAnimals();
            if (animas == null)
            {
                _logger.Error("AnimalsController: Get Animals is Failed");
                return NotFound();
            }

            _logger.Info("AnimalsController: Get Animals is Completed");
            return Ok(animas);
        }

        // GET: api/Animals/5

        [HttpGet("{id}")]
        public ActionResult<AnimalDto> GetAnimal(int id)
        {
            var animas = _animalService.GetAnimalById(id);
            if (animas == null)
            {
                _logger.Error("AnimalsController: Get Animal by ID is Failed");
                return NotFound();
            }
            _logger.Info("AnimalsController: Get Animal by ID is Completed");
            return Ok(animas);
        }

        [HttpGet()]
        [Route("~/api/v1/gawo/")]
        public async Task<ActionResult<IEnumerable<AnimalWithOwnerDto>>> GetAnimalswithOwners()
        {
            var animas = await _animalService.GetAnimalswithOwner();
            if (animas == null)
            {
                _logger.Error("AnimalsController: Get Animal With Owner is Failed");
                return NotFound();
            }
            _logger.Info("AnimalsController: Get Animal With Owner is Completed");
            return Ok(animas);
        }
        // PUT: api/Animals/5 
        [HttpPut("{id}")]
        public IActionResult PutAnimal(AnimalDto updateAnimalDto)
        {
            try
            {
                _animalService.UpdateAnimal(updateAnimalDto);
                _logger.Info("AnimalsController: Put Animal is Completed");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("AnimalsController: Put Animal is Failed" + exp.Message);
                return NotFound();
            }
        }
        // POST: api/Animals       
        [HttpPost]
        public ActionResult<AnimalDto> PostAnimal(AnimalDto AddAnimalDto)
        {
            try
            {
                _animalService.AddAnimal(AddAnimalDto);
                _logger.Info("AnimalsController: Post Animal is Completed");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("AnimalsController: Post Animal is Failed" + exp.Message);
                return BadRequest();
            }
        }
        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public ActionResult<AnimalDto> DeleteAnimal(int id)
        {
            try
            {
                _animalService.DeleteAnimal(id);
                _logger.Info("AnimalsController: Delete Animal is Completed");
                return Ok();
            }
            catch (Exception exp)
            {
                _logger.Error("AnimalsController: Delete Animal is Failed" + exp.Message);
                return NotFound();
            }
        }

    }
}
