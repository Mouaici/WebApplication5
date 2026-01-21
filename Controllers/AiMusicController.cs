using Microsoft.AspNetCore.Mvc;
using WebApplication5.Services;

namespace WebApplication5.Controllers;

[ApiController]
[Route("api/ai/music")]
public class AiMusicController : ControllerBase
{
    private readonly AiMusicService _service;

    public AiMusicController(AiMusicService service)
    {
        _service = service;
    }

    [HttpGet("playlist")]
    public async Task<IActionResult> Generate(
        [FromQuery] string genre,
        [FromQuery] string mood)
    {
        var result = await _service.GeneratePlaylist(genre, mood);
        return Ok(result);
    }
}
