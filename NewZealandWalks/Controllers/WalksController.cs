using Microsoft.AspNetCore.Mvc;
using NewZealandWalks.Models.DTOs;

namespace NewZealandWalks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WalksController : ControllerBase
{
    public async Task<IActionResult> Create([FromBody] AddWalkDto addWalkDto)
    {
        return Ok();
    }
}