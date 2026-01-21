using Microsoft.AspNetCore.Mvc;
using WebApplication5.Services;

namespace WebApplication5.Controllers;

[ApiController]
[Route("api/ai/music")]
public class AiMusicController : ControllerBase
{
    private readonly AiMusicService _ai;

    public AiMusicController(AiMusicService ai)
    {
        _ai = ai;
    }

    // GET: api/ai/music/playlist?genre=Pop&mood=Happy
    [HttpGet("playlist")]
    public async Task<IActionResult> Generate(string genre, string mood)
    {
        var result = await _ai.GeneratePlaylist(genre, mood);
        return Ok(result);
    }
}
