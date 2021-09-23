using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinaryClinic.DTOs;
using VeterinaryClinic.Models;
using VeterinaryClinic.Repository;
using VeterinaryClinic.Services;

public class VaccinationService : IVaccinationService
{
    private readonly IVaccinationRepository _vaccinationRepository;
    private readonly IMapper _mapper;
    public VaccinationService(IVaccinationRepository vaccinationRepository, IMapper mapper)
    {
        _vaccinationRepository = vaccinationRepository;
        _mapper = mapper;
    }

    public async Task<VaccinationDto> AddVaccination(VaccinationDto vaccinationforAdd)
    {
        Vaccination vaccination = _mapper.Map<Vaccination>(vaccinationforAdd);
        Task<Vaccination> result = _vaccinationRepository.AddVaccination(vaccination);
        var res = _mapper.Map<VaccinationDto>(result);
        return await Task.FromResult(res);
    }

    public async Task DeleteVaccination(int vaccinationIdforDelete)
    {
        await _vaccinationRepository.DeleteVaccination(vaccinationIdforDelete);
    }

    public async Task<VaccinationDto> GetVaccinationById(int vaccinationIdforGet)
    {
        var result = _vaccinationRepository.GetVaccinationById(vaccinationIdforGet);
        var res = _mapper.Map<VaccinationDto>(result);
        return await Task.FromResult(res);
    }

    public async Task<IList<VaccinationDto>> GetVaccinations()
    {
        var vaccinations = await _vaccinationRepository.GetVaccinations();
        return vaccinations.Select(x => _mapper.Map<VaccinationDto>(x)).ToList();
    }

    public async Task UpdateVaccination(VaccinationDto vaccinationforUpdate)
    {
        Vaccination vaccination = _mapper.Map<Vaccination>(vaccinationforUpdate);
        await _vaccinationRepository.UpdateVaccination(vaccination);
    }
}
