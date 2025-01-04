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
        public IActionResult GetAll()
        {
            // obtaining Domain Models
            var regions = _db.Regions.ToList();
            
            // converting to the DTOs
            var regionsDto = regions.Select(region => new RegionDto(region)).ToList();
            
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var it = _db.Regions.Find(id);
            
            if (it == null) return NotFound();
            
            var regionDto = new RegionDto(it);
                
            return Ok(regionDto);

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRegionDto newRegionDto)
        {
            var regionDomain = new Region(newRegionDto);
            
            _db.Regions.Add(regionDomain);
            _db.SaveChanges();

            var returnRegionDto = new RegionDto(regionDomain);
            
            return CreatedAtAction(nameof(Create), new {id = regionDomain.Id}, returnRegionDto); 
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            Region? originRegion = _db.Regions.FirstOrDefault(x => x.Id == id);
            if (originRegion == null) return NotFound();

            originRegion.Code = updateRegionDto.Code;
            originRegion.Name = updateRegionDto.Name;
            originRegion.RegionImageUrl = updateRegionDto.RegionImageUrl;

            _db.SaveChanges();

            var regionDto = new RegionDto(originRegion);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            Region? region = _db.Regions.Find(id);
            if (region is null) return NotFound();

            _db.Regions.Remove(region);
            _db.SaveChanges();

            RegionDto deletedRegion = new RegionDto(region);
            return Ok(deletedRegion);
        }
    }
}
