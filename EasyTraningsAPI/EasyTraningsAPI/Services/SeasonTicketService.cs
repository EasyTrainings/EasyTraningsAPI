using AutoMapper;
using EasyTraningsAPI.Models.DTOs;
using EasyTraningsAPI.Repositories;
using EasyTraningsAPI.Repositories.Interfaces;
using EasyTraningsAPI.Services.Interfaces.Interfaces;

namespace EasyTraningsAPI.Services.Interfaces;

public class SeasonTicketService(IMapper mapper, ISeasonTicketRepository seasonTicketRepository): ISeasonTicketService
{
    private readonly IMapper _mapper = mapper;
    private readonly ISeasonTicketRepository _seasonTicketRepository = seasonTicketRepository;

    public async Task<List<SeasonTicketDto>> GetAllAsync()
    {
        return _mapper.Map<List<SeasonTicketDto>>((await _seasonTicketRepository.GetAllAsync())?.ToList());
    }
    public async Task<SeasonTicketDto> GetByIdAsync(int id)
    {
        return _mapper.Map<SeasonTicketDto>(await _seasonTicketRepository.GetByIdAsync(id));
    }

    public async Task<SeasonTicketDto> AddAsync(SeasonTicketDto seasonTicket)
    {
        return _mapper.Map<SeasonTicketDto>(await _seasonTicketRepository.AddAsync(_mapper.Map<SeasonTicket.Entities.SeasonTicket>(seasonTicket)));
    }

    public async Task UpdateAsync(int id, SeasonTicketDto seasonTicket)
    {
        await _seasonTicketRepository.UpdateAsync(id, _mapper.Map<SeasonTicket.Entities.SeasonTicket>(seasonTicket));
    }

    public async Task DeleteAsync(int id)
    {
        await _seasonTicketRepository.DeleteAsync(id);
    }
}