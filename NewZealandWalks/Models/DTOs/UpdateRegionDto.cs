namespace NewZealandWalks.Models.DTOs;

public class UpdateRegionDto : IRegionDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
}