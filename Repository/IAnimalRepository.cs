using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Repository
{
    public interface IAnimalRepository
    {
        public Task<IList<Animal>> GetAnimals();
        public Task<IList<AnimalWithOwnerDto>> GetAnimalswithOwner();
        public Task<Animal> AddAnimal(Animal animalForAdd);
        public Task UpdateAnimal(Animal AnimalforUpdate);
        public Task DeleteAnimal(int animalId);
        public Animal GetAnimalById(int animalId);
    }
}
