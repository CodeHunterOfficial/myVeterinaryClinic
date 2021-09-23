using myVeterinaryClinic.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;

namespace myVeterinaryClinic.Services
{
    public interface IDocServService
    {
        public Task<IList<DocServDto>> GetDocServs();
        public Task<IList<DoctorDto>> GetListOfDoctors(int serviceId);
        public Task<IList<ServiceDto>> GetListOfService(int doctorId);
        public Task<DocServDto> AddDocServ(DocServDto docServForAdd);
        public Task UpdateDocServ(DocServDto docServforUpdate);
        public Task DeleteDocServ(int docServIdForDelete);
        public Task<DocServDto> GetDocServById(int docServIdForGet);
    }
}
