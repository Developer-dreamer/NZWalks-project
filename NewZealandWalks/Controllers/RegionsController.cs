using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewZealandWalks.Data;
using NewZealandWalks.Models.Domain;
using NewZealandWalks.Models.DTOs;
using NewZealandWalks.Repositories;

namespace NewZealandWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // obtaining Domain Models
            var regions = await _regionRepository.GetAllAsync();
            
            // converting to the DTOs
            var regionsDto = regions.Select(region => new RegionDto(region)).ToList();
            
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var it = await _regionRepository.FindAsync(id);
            
            if (it == null) return NotFound();
            
            var regionDto = new RegionDto(it);
                
            return Ok(regionDto);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionDto newRegionDto)
        {
            var regionDomain = new Region(newRegionDto);
            
            await _regionRepository.AddAsync(regionDomain);

            var returnRegionDto = new RegionDto(regionDomain);
            
            return CreatedAtAction(nameof(Create), new {id = regionDomain.Id}, returnRegionDto); 
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            Region? originRegion = await _regionRepository.FindAsync(id);
            if (originRegion == null) return NotFound();

            await _regionRepository.UpdateAsync(originRegion, updateRegionDto);

            var regionDto = new RegionDto(originRegion);

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Region? region = await _regionRepository.FindAsync(id);
            if (region is null) return NotFound();
            
            await _regionRepository.DeleteAsync(region);

            RegionDto deletedRegion = new RegionDto(region);
            return Ok(deletedRegion);
        }
    }
}
