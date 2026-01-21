namespace WebApplication5.Services;

public class AiMusicService
{
    public Task<List<string>> GeneratePlaylist(string genre, string mood)
    {
        var playlist = new List<string>
        {
            $"{genre} Track 1 ({mood})",
            $"{genre} Track 2 ({mood})",
            $"{genre} Track 3 ({mood})"
        };

        return Task.FromResult(playlist);
    }
}
