using AutoMapper;
using myVeterinaryClinic.DTOs;
using myVeterinaryClinic.Models;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.ApiMappings
{
    public class ApiMappings : Profile
    {
        public ApiMappings()
        {
            this.CreateMap<Animal, AnimalDto>();
            this.CreateMap<AnimalDto, Animal>();

            this.CreateMap<Owner, OwnerDto>();
            this.CreateMap<OwnerDto, Owner>();

            this.CreateMap<Doctor, DoctorDto>();
            this.CreateMap<DoctorDto, Doctor>();

            this.CreateMap<Service, ServiceDto>();
            this.CreateMap<ServiceDto, Service>();

            this.CreateMap<Vaccination, VaccinationDto>();
            this.CreateMap<VaccinationDto, Vaccination>();

            this.CreateMap<DocServ, DocServDto>();
            this.CreateMap<DocServDto, DocServ>();
        }
    }
}