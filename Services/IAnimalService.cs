using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
namespace VeterinaryClinic.Services
{
    public interface IAnimalService
    {
        public Task<IList<AnimalDto>> GetAnimals();
        public Task<IList<AnimalWithOwnerDto>> GetAnimalswithOwner();
        public Task<AnimalDto> AddAnimal(AnimalDto animalForAdd);
        public Task UpdateAnimal(AnimalDto AnimalforUpdate);
        public Task DeleteAnimal(int animalId);
        public Task<AnimalDto> GetAnimalById(int animalId);
    }
}
