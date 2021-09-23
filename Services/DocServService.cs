using AutoMapper;
using myVeterinaryClinic.DTOs;
using myVeterinaryClinic.Models;
using myVeterinaryClinic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;

namespace myVeterinaryClinic.Services
{
    public class DocServService : IDocServService
    {
        private readonly IDocServRepository _docServRepository;
        private readonly IMapper _mapper;
        public DocServService(IDocServRepository docServRepository, IMapper mapper)
        {
            _docServRepository = docServRepository;
            _mapper = mapper;
        }

        public async Task<DocServDto> AddDocServ(DocServDto docServForAdd)
        {
            DocServ docServ = _mapper.Map<DocServ>(docServForAdd);
            var result = _docServRepository.AddDocServ(docServ);
            var res = _mapper.Map<DocServDto>(result);
            return await Task.FromResult(res);
        }

        public async Task DeleteDocServ(int docServIdForDelete)
        {
            await _docServRepository.DeleteDocServ(docServIdForDelete);
        }

        public async Task<IList<DocServDto>> GetDocServs()
        {
            var docservs = await _docServRepository.GetDocServs();
            return docservs.Select(x => _mapper.Map<DocServDto>(x)).ToList();
        }

        public async Task<DocServDto> GetDocServById(int docServIdForGet)
        {
            var result = _docServRepository.GetDocServById(docServIdForGet);
            var res = _mapper.Map<DocServDto>(result);
            return await Task.FromResult(res);
        }

        public async Task<IList<DoctorDto>> GetListOfDoctors(int serviceId)
        {
            var doctors = await _docServRepository.GetListOfDoctors(serviceId);
            return doctors.Select(x => _mapper.Map<DoctorDto>(x)).ToList();
        }

        public async Task<IList<ServiceDto>> GetListOfService(int doctorId)
        {
            var services = await _docServRepository.GetListOfService(doctorId);
            return services.Select(x => _mapper.Map<ServiceDto>(x)).ToList();
        }

        public async Task UpdateDocServ(DocServDto docServforUpdate)
        {
            DocServ docserv = _mapper.Map<DocServ>(docServforUpdate);
            await _docServRepository.UpdateDocServ(docserv);
        }
    }
}
