using FirstAPI.Context;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class VideosController : ControllerBase
{
    private readonly ApiContext _context;

    public VideosController(ApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
    {
        return await _context.Videos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Video>> GetVideo(int id)
    {
        var video = await _context.Videos.FindAsync(id);

        if (video == null)
        {
            return NotFound();
        }

        return video;
    }

    [HttpPost]
    public async Task<ActionResult<Video>> PostVideo(Video video)
    {
        _context.Videos.Add(video);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVideo), new { id = video.Id }, video);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutVideo(int id, Video video)
    {
        if (id != video.Id)
        {
            return BadRequest();
        }

        _context.Entry(video).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Videos.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVideo(int id)
    {
        var video = await _context.Videos.FindAsync(id);
        if (video == null)
        {
            return NotFound();
        }

        _context.Videos.Remove(video);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
