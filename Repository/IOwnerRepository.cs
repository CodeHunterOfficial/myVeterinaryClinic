using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.Models;
namespace VeterinaryClinic.Repository
{
    public interface IOwnerRepository
    {
        public  Task<IList<Owner>> GetOwners();
        public Task<Owner> AddOwner(Owner ownerForAdd);
        public Task UpdateOwner(Owner ownerforUpdate);
        public Task DeleteOwner(int ownerIdForDelete);
        public Owner GetOwnerById(int ownerIdForGet);       
    }
}
