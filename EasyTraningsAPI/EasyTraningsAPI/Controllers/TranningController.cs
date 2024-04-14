using EasyTraningsAPI.Models.DTOs;
using EasyTraningsAPI.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyTraningsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TranningController(ITranningService tranningService): ControllerBase
{
    private readonly ITranningService _tranningService = tranningService;
    
    [HttpGet]
    public async Task<IActionResult> GetAllTranning()
    {
        try
        {
            var tranning = await _tranningService.GetAllAsync();
            return Ok(tranning);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAllTranningId(int id)
    {
        try
        {
            var tranning = await _tranningService.GetByIdAsync(id);
            return Ok(tranning);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddTranning([FromBody] TranningDto tranning)
    {
        try
        {
            var tranningAdded = await _tranningService.AddAsync(tranning);
            return Ok(tranningAdded);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateTranning(int id, [FromBody] TranningDto tranning)
    {
        try
        {
            await _tranningService.UpdateAsync(id, tranning);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTranning(int id)
    {
        try
        {
            await _tranningService.DeleteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}