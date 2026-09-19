using Microsoft.EntityFrameworkCore;
using ShiftLogger.Models;

namespace ShiftLogger.Data;

public class ShiftDbContext : DbContext
{
    public DbSet<Shift> Shift { get; set; }
    public ShiftDbContext(DbContextOptions options) : base(options)
    {

    }
}
