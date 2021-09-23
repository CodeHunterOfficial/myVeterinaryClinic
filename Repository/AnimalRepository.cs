using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
using NLog;

namespace VeterinaryClinic.Repository
{
    public class AnimalRepository : IAnimalRepository
    {

        private readonly VeterinaryClinicContext _context;
        private readonly ILogger _logger;
        public AnimalRepository(VeterinaryClinicContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }
        public async Task<Animal> AddAnimal(Animal animalForAdd)
        {
            Animal newAnimal = new Animal()
            {
                Name = animalForAdd.Name,
                OwnerId = animalForAdd.OwnerId
            };
            try
            {
                _context.Animals.Add(newAnimal);
                await _context.SaveChangesAsync();
                _logger.Info("Start: Add Animal:");
                return newAnimal;
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Add Animal is Failed: " + exp.Message);
                return null;
            }
        }

        public async Task DeleteAnimal(int animalId)
        {
            try
            {
                var animalforDelete = GetAnimalById(animalId);
                _context.Animals.Remove(animalforDelete);
                await _context.SaveChangesAsync();
                _logger.Info("Start: Delete Animal by ID ");
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Delete animal by ID Is Failed:" + exp.Message);
            }
        }
        public Animal GetAnimalById(int animalId)
        {
            try
            {
                var result = (_context.Animals.FirstOrDefault(x => x.AnimalId == animalId));
                _logger.Info("Start: Getting Animal for ID: {0}", animalId);
                return result;
            }
            catch (Exception exp)
            {
                _logger.Error($"Start: Get Animals by ID: {0}   is Failed: {1}",animalId,exp.Message);
                return null;
            }
        }

        public async Task<IList<Animal>> GetAnimals()
        {
            try
            {
                _logger.Info("Start:  Get List Of Animals is Completed ");
                return await _context.Animals.ToListAsync();
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Get List Of Animals is Failed:" + exp.Message);
                return null;
            }
        }

        public async Task<IList<AnimalWithOwnerDto>> GetAnimalswithOwner()
        {
            try
            {
                var sql = (from ap in _context.Animals
                           join op in _context.Owners on ap.OwnerId equals op.OwnerId
                           select new AnimalWithOwnerDto
                           {
                               AnimalId = ap.AnimalId,
                               Name = ap.Name,
                               OwnerName = op.FullName
                           }).ToListAsync();
                _logger.Info("Start: Get item details for AnimalswithOwner is Completed ");
                return await sql;
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Getting item details for AnimalswithOwner  is Failed: " + exp.Message);
                return null;
            }
        }

        public async Task UpdateAnimal(Animal AnimalforUpdate)
        {
            try
            {
                _context.Entry(AnimalforUpdate).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _logger.Info("Start: Update is Completed ");
            }
            catch (Exception exp)
            {
                _logger.Error("Start: Update Animal is Failed: " + exp.Message);
            }
        }
    }
}