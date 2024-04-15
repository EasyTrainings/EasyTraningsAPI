using AutoMapper;
using EasyTraningsAPI.Models.DTOs;
using EasyTraningsAPI.Repositories;
using EasyTraningsAPI.Repositories.Interfaces;
using EasyTraningsAPI.Services.Interfaces.Interfaces;


namespace EasyTraningsAPI.Services.Interfaces;

public class TranningService(IMapper mapper, ITranningRepository tranningRepository): ITranningService
{
    private readonly IMapper _mapper = mapper;
    private readonly ITranningRepository _tranningRepository = tranningRepository;

    public async Task<List<TranningDto>> GetAllAsync()
    {
        return _mapper.Map<List<TranningDto>>((await _tranningRepository.GetAllAsync())?.ToList());
    }
    public async Task<TranningDto> GetByIdAsync(int id)
    {
        return _mapper.Map<TranningDto>(await _tranningRepository.GetByIdAsync(id));
    }

    public async Task<TranningDto> AddAsync(TranningDto tranning)
    {
        return _mapper.Map<TranningDto>(await _tranningRepository.AddAsync(_mapper.Map<Tranning.Entities.Tranning>(tranning)));
    }

    public async Task UpdateAsync(int id, TranningDto tranning)
    {
        await _tranningRepository.UpdateAsync(id, _mapper.Map<Tranning.Entities.Tranning>(tranning));
    }

    public async Task DeleteAsync(int id)
    {
        await _tranningRepository.DeleteAsync(id);
    }
}