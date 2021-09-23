using myVeterinaryClinic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinaryClinic.Models;

namespace myVeterinaryClinic.Repository
{
    public interface IDocServRepository
    {
        public Task<IList<DocServ>> GetDocServs();
        public Task<IList<Doctor>> GetListOfDoctors(int serviceId);
        public Task<IList<Service>> GetListOfService(int doctorId);
        public Task<DocServ> AddDocServ(DocServ docServForAdd);
        public Task UpdateDocServ(DocServ docServforUpdate);
        public Task DeleteDocServ(int docServIdForDelete);
        public DocServ GetDocServById(int docServIdForGet);
    }
}
