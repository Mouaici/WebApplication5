using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data;

public class RadioStationDbContext : DbContext
{
    public RadioStationDbContext(DbContextOptions<RadioStationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contributor> Contributors => Set<Contributor>();
}
