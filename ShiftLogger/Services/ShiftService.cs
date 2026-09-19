using Microsoft.EntityFrameworkCore;
using ShiftLogger.Data;
using ShiftLogger.DTO;
using ShiftLogger.Models;

namespace ShiftLogger.Services;

public class ShiftService : IShiftService
{
    private readonly ShiftDbContext _shiftDbContext;
    public ShiftService(ShiftDbContext shiftDbContext)
    {
        _shiftDbContext = shiftDbContext;
    }
    public async Task<Shift> CreateShift(CreateShiftDTO shiftDTO)
    {
        var shift = new Shift { StartTime = shiftDTO.StartTime, EndTime = shiftDTO.EndTime };
        _shiftDbContext.Add(shift);
        await _shiftDbContext.SaveChangesAsync();
        return shift;
    }

    public async Task<bool> DeleteShift(int id)
    {
        var shift = await _shiftDbContext.Shift.FindAsync(id);
        if (shift is null)
        {
            return false;
        }
        _shiftDbContext.Shift.Remove(shift);
        await _shiftDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Shift>> GetAllShifts()
    {
        return await _shiftDbContext.Shift.ToListAsync();
    }

    public async Task<Shift?> GetShiftById(int id)
    {
        var shift = await _shiftDbContext.Shift.FindAsync(id);
        return shift;
    }

    public async Task<Shift?> UpdateShift(int id, UpdateShiftDTO shiftDTO)
    {
        var shift = await _shiftDbContext.Shift.FindAsync(id);
        if (shift is null)
        {
            return null;
        }
        shift.StartTime = shiftDTO.StartTime;
        shift.EndTime = shiftDTO.EndTime;
        await _shiftDbContext.SaveChangesAsync();
        return shift;
    }
}
