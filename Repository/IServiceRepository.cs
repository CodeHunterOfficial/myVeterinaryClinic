using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.Models;
namespace VeterinaryClinic.Repository
{
    public interface IServiceRepository
    {
        public Task<IList<Service>> GetServices();
        public Task<Service> AddService(Service serviceforAdd);
        public Task UpdateService( Service serviceforUpdate);
        public Task DeleteService(int serviceId);
        public Service GetServiceById(int serviceId);
    }
}
