using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
using VeterinaryClinic.Repository;

namespace VeterinaryClinic.Services
{
    public class AnimalService : IAnimalService
    {

        private readonly IAnimalRepository _aninalRepository;
        private readonly IMapper _mapper;
        public AnimalService(IAnimalRepository aninalRepository, IMapper mapper)
        {
            _aninalRepository = aninalRepository;
            _mapper = mapper;
        }

        public async Task<AnimalDto> AddAnimal(AnimalDto animalForAdd)
        {
            Animal animal = _mapper.Map<Animal>(animalForAdd);
            Task<Animal> result = _aninalRepository.AddAnimal(animal);
            var res = _mapper.Map<AnimalDto>(result);
            return await Task.FromResult(res);
        }

        public async Task DeleteAnimal(int animalId)
        {
            await _aninalRepository.DeleteAnimal(animalId);
        }

        public async Task<AnimalDto> GetAnimalById(int animalId)
        {
            var result = _aninalRepository.GetAnimalById(animalId);
            var res = _mapper.Map<AnimalDto>(result);
            return await Task.FromResult(res);
        }

        public async Task<IList<AnimalDto>> GetAnimals()
        {
            var owners = await _aninalRepository.GetAnimals();
            return owners.Select(x => _mapper.Map<AnimalDto>(x)).ToList();
        }

        public async Task<IList<AnimalWithOwnerDto>> GetAnimalswithOwner()
        {
            var animalWithOwner = _aninalRepository.GetAnimalswithOwner();
            return await animalWithOwner;
        }

        public async Task UpdateAnimal(AnimalDto AnimalforUpdate)
        {
            Animal animal = _mapper.Map<Animal>(AnimalforUpdate);
            await _aninalRepository.UpdateAnimal(animal);
        }
    }
}
