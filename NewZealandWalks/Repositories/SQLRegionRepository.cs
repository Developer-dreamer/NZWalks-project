using Microsoft.EntityFrameworkCore;
using NewZealandWalks.Data;
using NewZealandWalks.Models.Domain;
using NewZealandWalks.Models.DTOs;

namespace NewZealandWalks.Repositories;

public class SQLRegionRepository : IRegionRepository
{
    private readonly NzWalksDbContext _dbContext;

    public SQLRegionRepository(NzWalksDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Region>> GetAllAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }

    public async Task<Region?> FindAsync(Guid id)
    {
        return await _dbContext.Regions.FindAsync(id);
    }

    public async Task AddAsync(Region region)
    {
        await _dbContext.Regions.AddAsync(region);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Region originRegion , UpdateRegionDto updatedRegion)
    {
        originRegion.Code = updatedRegion.Code;
        originRegion.Name = updatedRegion.Name;
        originRegion.RegionImageUrl = updatedRegion.RegionImageUrl;
        
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Region region)
    {
        _dbContext.Regions.Remove(region);
        await _dbContext.SaveChangesAsync();
    }
}