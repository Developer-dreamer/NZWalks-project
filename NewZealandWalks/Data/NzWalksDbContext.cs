using Microsoft.EntityFrameworkCore;
using NewZealandWalks.Models.Domain;

namespace NewZealandWalks.Data;

public class NzWalksDbContext : DbContext
{
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
    
    public NzWalksDbContext(DbContextOptions options) : base(options) { }
}