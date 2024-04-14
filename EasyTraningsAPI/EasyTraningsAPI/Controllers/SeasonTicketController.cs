using EasyTraningsAPI.Models.DTOs;
using EasyTraningsAPI.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTraningsAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class SeasonTicketController(ISeasonTicketService seasonTicketService): ControllerBase
{
    private readonly ISeasonTicketService _seasonTicketService = seasonTicketService;
    
    [HttpGet]
    public async Task<IActionResult> GetAllSeasonTicket()
    {
        try
        {
            var seasonTicket = await _seasonTicketService.GetAllAsync();
            return Ok(seasonTicket);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAllSeasonTicketId(int id)
    {
        try
        {
            var seasonTicket = await _seasonTicketService.GetByIdAsync(id);
            return Ok(seasonTicket);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddSeasonTicket([FromBody] SeasonTicketDto seasonTicket)
    {
        try
        {
            var seasonTicketAdded = await _seasonTicketService.AddAsync(seasonTicket);
            return Ok(seasonTicketAdded);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateSeasonTicket(int id, [FromBody] SeasonTicketDto seasonTicket)
    {
        try
        {
            await _seasonTicketService.UpdateAsync(id, seasonTicket);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteSeasonTicket(int id)
    {
        try
        {
            await _seasonTicketService.DeleteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}