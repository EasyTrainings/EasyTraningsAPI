using EasyTraningsAPI.Models.DTOs;

namespace EasyTraningsAPI.Services.Interfaces.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task<UserDto> AddAsync(UserDto user);
    Task UpdateAsync(int id, UserDto user);
    Task DeleteAsync(int id);
}