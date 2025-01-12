using NewZealandWalks.Models.Domain;

namespace NewZealandWalks.Models.DTOs;

public class RegionDto : IRegionDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
}