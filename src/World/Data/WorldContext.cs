using System.Reflection;
using Microsoft.EntityFrameworkCore;
using World.Entities;

namespace World.Data;

public class WorldContext(DbContextOptions<WorldContext> options) : DbContext(options)
{
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Region> Regions { get; set; } = null!;
    public DbSet<State> States { get; set; } = null!;
    public DbSet<SubRegion> SubRegions { get; set; } = null!;
    
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}