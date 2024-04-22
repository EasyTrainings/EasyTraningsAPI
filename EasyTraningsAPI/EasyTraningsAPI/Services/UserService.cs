using AutoMapper;
using EasyTraningsAPI.Models.DTOs;
using EasyTraningsAPI.Repositories;
using EasyTraningsAPI.Repositories.Interfaces;
using EasyTraningsAPI.Services.Interfaces.Interfaces;

namespace EasyTraningsAPI.Services.Interfaces;

public class UserService(IMapper mapper, IUserRepository userRepository): IUserService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<List<UserDto>> GetAllAsync()
    {
        return _mapper.Map<List<UserDto>>((await _userRepository.GetAllAsync())?.ToList());
    }
    public async Task<UserDto> GetByIdAsync(int id)
    {
        return _mapper.Map<UserDto>(await _userRepository.GetByIdAsync(id));
    }

    public async Task<UserDto> AddAsync(UserDto user)
    {
        User.Entities.User newUser = await _userRepository.AddAsync(_mapper.Map<User.Entities.User>(user));
        newUser.CreatedAt = DateTime.Now;
        newUser.UpdatedAt = DateTime.Now;
        return _mapper.Map<UserDto>(newUser);
    }

    public async Task UpdateAsync(int id, UserDto user)
    {
        await _userRepository.UpdateAsync(id, _mapper.Map<User.Entities.User>(user));
    }

    public async Task DeleteAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }
}
