using Microsoft.EntityFrameworkCore;
using NZWalks_solution.Models.Domain;

namespace NZWalks_solution.Data;

public class NzWalksDbContext : DbContext
{
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
    
    public NzWalksDbContext(DbContextOptions options) : base(options) { }
}