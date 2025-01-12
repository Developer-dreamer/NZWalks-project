using Microsoft.EntityFrameworkCore;
using NewZealandWalks.Models;
using NewZealandWalks.Models.Domain;
using NewZealandWalks.Models.DTOs;

namespace NewZealandWalks.Models;

public static class Mapper
{
    public static IRegionDto MapTo<TDestination>(Region origin)
    {
        if (origin == null)
            throw new ArgumentNullException(nameof(origin));
    
        return typeof(TDestination) switch
        {
            var type when type == typeof(RegionDto) =>
                ToRegionDto(origin),
            var type when type == typeof(CreateRegionDto) => 
                ToCreateRegionDto(origin),
            var type when type == typeof(UpdateRegionDto) => 
                ToUpdateRegionDto(origin),
            _ => throw new InvalidOperationException($"Unsupported type: {typeof(TDestination).Name}")
        };
        
    }
    
    public static Region MapFrom<TOrigin>(TOrigin dto){
        if(dto == null)
            throw new ArgumentNullException(nameof(dto));
        
        return typeof(TOrigin) switch
        {
            var type when type == typeof(RegionDto) =>
                FromRegionDto((dto as RegionDto)!),
            var type when type == typeof(CreateRegionDto) => 
                FromCreateRegionDto((dto as CreateRegionDto)!),
            var type when type == typeof(UpdateRegionDto) => 
                FromUpdateRegionDto((dto as UpdateRegionDto)!),
            _ => throw new InvalidOperationException($"Unsupported type: {typeof(TOrigin).Name}")
        };
    }
    
    // matching to the DTOs
    private static RegionDto ToRegionDto(Region origin)
    {
        return new RegionDto()
        {
            Id = origin.Id,
            Code = origin.Code,
            Name = origin.Name,
            RegionImageUrl = origin.RegionImageUrl
        };
        
    }
    
    private static CreateRegionDto ToCreateRegionDto(Region origin)
    {
        return new CreateRegionDto()
        {
            Code = origin.Code,
            Name = origin.Name,
            RegionImageUrl = origin.RegionImageUrl
        };
    }

    private static UpdateRegionDto ToUpdateRegionDto(Region origin)
    {
        return new UpdateRegionDto()
        {
            Code = origin.Code,
            Name = origin.Name,
            RegionImageUrl = origin.RegionImageUrl
        };
    }
    

    // matching from the dto
    private static Region FromRegionDto(RegionDto dto)
    {
        return new Region()
        {
            Id = dto.Id,
            Code = dto.Code,
            Name = dto.Name,
            RegionImageUrl = dto.RegionImageUrl
        };
    }
    private static Region FromCreateRegionDto(CreateRegionDto dto)
    {
        return new Region()
        {
            Id = Guid.NewGuid(),
            Code = dto.Code,
            Name = dto.Name,
            RegionImageUrl = dto.RegionImageUrl
        };
    }

    private static Region FromUpdateRegionDto(UpdateRegionDto dto)
    {
        return new Region()
        {
            Id = Guid.NewGuid(),
            Code = dto.Code,
            Name = dto.Name,
            RegionImageUrl = dto.RegionImageUrl
        };
    }
}