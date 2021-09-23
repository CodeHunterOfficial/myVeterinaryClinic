using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
using VeterinaryClinic.Repository;
namespace VeterinaryClinic.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<ServiceDto> AddService(ServiceDto serviceforAdd)
        {
            Service service = _mapper.Map<Service>(serviceforAdd);
            var result = _serviceRepository.AddService(service);
            var res = _mapper.Map<ServiceDto>(result);
            return await Task.FromResult(res);
        }

        public async Task DeleteService(int serviceId)
        {
            await _serviceRepository.DeleteService(serviceId);
        }

        public async Task<ServiceDto> GetServiceById(int serviceId)
        {
            var result = _serviceRepository.GetServiceById(serviceId);
            var res = _mapper.Map<ServiceDto>(result);
            return await Task.FromResult(res);
        }

        public async Task<IList<ServiceDto>> GetServices()
        {
            var services = await _serviceRepository.GetServices();
            return services.Select(x => _mapper.Map<ServiceDto>(x)).ToList();
        }

        public async Task UpdateService(ServiceDto serviceforUpdate)
        {
            Service service = _mapper.Map<Service>(serviceforUpdate);
            await _serviceRepository.UpdateService(service);
        }
    }
}
