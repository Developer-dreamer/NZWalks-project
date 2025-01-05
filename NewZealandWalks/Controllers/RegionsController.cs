using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewZealandWalks.Data;
using NewZealandWalks.Models.Domain;
using NewZealandWalks.Models.DTOs;

namespace NewZealandWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NzWalksDbContext _db;
        
        public RegionsController(NzWalksDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // obtaining Domain Models
            var regions = await _db.Regions.ToListAsync();
            
            // converting to the DTOs
            var regionsDto = regions.Select(region => new RegionDto(region)).ToList();
            
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var it = await _db.Regions.FindAsync(id);
            
            if (it == null) return NotFound();
            
            var regionDto = new RegionDto(it);
                
            return Ok(regionDto);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionDto newRegionDto)
        {
            var regionDomain = new Region(newRegionDto);
            
            await _db.Regions.AddAsync(regionDomain);
            await _db.SaveChangesAsync();

            var returnRegionDto = new RegionDto(regionDomain);
            
            return CreatedAtAction(nameof(Create), new {id = regionDomain.Id}, returnRegionDto); 
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            Region? originRegion = await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (originRegion == null) return NotFound();

            originRegion.Code = updateRegionDto.Code;
            originRegion.Name = updateRegionDto.Name;
            originRegion.RegionImageUrl = updateRegionDto.RegionImageUrl;

            await _db.SaveChangesAsync();

            var regionDto = new RegionDto(originRegion);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Region? region = await _db.Regions.FindAsync(id);
            if (region is null) return NotFound();

            _db.Regions.Remove(region);
            await _db.SaveChangesAsync();

            RegionDto deletedRegion = new RegionDto(region);
            return Ok(deletedRegion);
        }
    }
}
