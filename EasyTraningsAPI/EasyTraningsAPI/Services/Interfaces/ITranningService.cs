using EasyTraningsAPI.Models.DTOs;

namespace EasyTraningsAPI.Services.Interfaces.Interfaces;

public interface ITranningService
{
    Task<List<TranningDto>> GetAllAsync();
    Task<TranningDto> GetByIdAsync(int id);
    Task<TranningDto> AddAsync(TranningDto tranning);
    Task UpdateAsync(int id, TranningDto tranning);
    Task DeleteAsync(int id);
}