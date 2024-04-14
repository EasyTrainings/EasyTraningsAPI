using EasyTraningsAPI.Models.DTOs;
using EasyTraningsAPI.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTraningsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService): ControllerBase
{
    private readonly IUserService _userService = userService;
    
    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        try
        {
            var user = await _userService.GetAllAsync();
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAllUserId(int id)
    {
        try
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserDto user)
    {
        try
        {
            var userAdded = await _userService.AddAsync(user);
            return Ok(userAdded);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto user)
    {
        try
        {
            await _userService.UpdateAsync(id, user);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}