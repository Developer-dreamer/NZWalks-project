using NewZealandWalks.Models.Domain;
using NewZealandWalks.Models.DTOs;

namespace NewZealandWalks.Repositories;

public interface IRegionRepository
{
    Task<List<Region>> GetAllAsync();
    Task<Region?> FindAsync(Guid id);
    Task AddAsync(Region region);
    Task UpdateAsync(Region originRegion , UpdateRegionDto updatedRegion);
    Task DeleteAsync(Region region);
}