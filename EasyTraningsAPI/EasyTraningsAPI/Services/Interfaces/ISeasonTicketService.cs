using EasyTraningsAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EasyTraningsAPI.Services.Interfaces.Interfaces;

public interface ISeasonTicketService
{
    Task<List<SeasonTicketDto>> GetAllAsync();
    Task<SeasonTicketDto> GetByIdAsync(int id);
    Task<SeasonTicketDto> AddAsync(SeasonTicketDto seasonTicket);
    Task UpdateAsync(int id, SeasonTicketDto seasonTicket);
    Task DeleteAsync(int id);

}