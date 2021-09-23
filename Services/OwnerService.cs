using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
using VeterinaryClinic.Repository;
namespace VeterinaryClinic.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }
        public async Task<IList<OwnerDto>> GetOwners()
        {
            var owners = await _ownerRepository.GetOwners();
            return owners.Select(x => _mapper.Map<OwnerDto>(x)).ToList();
        }
        public async Task<OwnerDto> AddOwner(OwnerDto ownerForAdd)
        {
            Owner owner = _mapper.Map<Owner>(ownerForAdd);
            Task<Owner> result = _ownerRepository.AddOwner(owner);
            var res = _mapper.Map<OwnerDto>(result);
            return await Task.FromResult(res);
        }
        public async Task UpdateOwner(OwnerDto ownerForUpdate)
        {
            Owner owner = _mapper.Map<Owner>(ownerForUpdate);
            await _ownerRepository.UpdateOwner(owner);
        }
        public async Task DeleteOwner(int ownerIdForDelete)
        {
            await _ownerRepository.DeleteOwner(ownerIdForDelete);
        }
        public async Task<OwnerDto> GetOwnerById(int ownerIdForGet)
        {
            var result = _ownerRepository.GetOwnerById(ownerIdForGet);
            var res = _mapper.Map<OwnerDto>(result);
            return await Task.FromResult(res);
        }
    }
}
