using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
namespace VeterinaryClinic.Services
{
    public interface IServiceService
    {
        public Task<IList<ServiceDto>> GetServices();
        public Task<ServiceDto> AddService(ServiceDto serviceforAdd);
        public Task UpdateService(ServiceDto serviceforUpdate);
        public Task DeleteService(int serviceId);
        public Task<ServiceDto> GetServiceById(int serviceId);
    }
}
