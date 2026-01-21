using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data;

public class RadioStationDbContext : DbContext
{
    public RadioStationDbContext(DbContextOptions<RadioStationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contributor> Contributors => Set<Contributor>();
}
