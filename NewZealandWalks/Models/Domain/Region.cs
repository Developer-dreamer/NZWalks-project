using NewZealandWalks.Models.DTOs;

namespace NewZealandWalks.Models.Domain;

public class Region
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
    
    public Region(){ }
    
    public Region(CreateRegionDto regionDto)
    {
        Id = Guid.NewGuid();
        Code = regionDto.Code;
        Name = regionDto.Name;
        RegionImageUrl = regionDto.RegionImageUrl;
    }
}