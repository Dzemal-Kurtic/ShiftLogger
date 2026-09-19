using Microsoft.AspNetCore.Mvc;
using ShiftLogger.DTO;
using ShiftLogger.Models;
using ShiftLogger.Services;

namespace ShiftLogger.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftController : ControllerBase
{
    private readonly IShiftService _shiftService;
    public ShiftController(IShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    [HttpPost]
    public async Task<ActionResult<Shift>> CreateShift(CreateShiftDTO shiftDTO)
    {
        var created = await _shiftService.CreateShift(shiftDTO);
        return CreatedAtAction(nameof(GetShiftById), new { id = created.Id }, created);
    }

    [HttpGet]
    public async Task<ActionResult<List<Shift>>> GetAllShifts()
    {
        return await _shiftService.GetAllShifts();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Shift>> GetShiftById(int id)
    {
        var shift = await _shiftService.GetShiftById(id);
        if (shift is null)
        {
            return NotFound();
        }
        return Ok(shift);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteShift(int id)
    {
        var deleted = await _shiftService.DeleteShift(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Shift>> UpdateShift(int id, UpdateShiftDTO shiftDTO)
    {
        var shift = await _shiftService.UpdateShift(id, shiftDTO);
        if (shift is null)
        {
            return NotFound();
        }
        return NoContent();
    }
}
