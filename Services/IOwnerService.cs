using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
namespace VeterinaryClinic.Services
{
    public interface IOwnerService
    {
        public Task<IList<OwnerDto>> GetOwners();
        public Task<OwnerDto> AddOwner(OwnerDto ownerForAdd);
        public Task UpdateOwner(OwnerDto ownerForUpdate);
        public Task DeleteOwner(int ownerIdForDelete);
        public Task<OwnerDto> GetOwnerById(int ownerIdForGet);        
    }
}
