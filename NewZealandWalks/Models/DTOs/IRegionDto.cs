namespace NewZealandWalks.Models.DTOs;

public interface IRegionDto
{
    public string Code { get; }
    public string Name { get; }
    public string? RegionImageUrl { get; }
}