using ShiftLogger.DTO;
using ShiftLogger.Models;

namespace ShiftLogger.Services;

public interface IShiftService
{
    public Task<List<Shift>> GetAllShifts();
    public Task<Shift?> GetShiftById(int id);
    public Task<Shift> CreateShift(CreateShiftDTO shift);
    public Task<Shift?> UpdateShift(int id, UpdateShiftDTO shift);
    public Task<bool> DeleteShift(int id);
}
