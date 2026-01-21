using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContributorController : ControllerBase
{
    private readonly RadioStationDbContext _context;

    public ContributorController(RadioStationDbContext context)
    {
        _context = context;
    }

    // GET: api/Contributor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contributor>>> GetAll()
    {
        return await _context.Contributors.ToListAsync();
    }

    // POST: api/Contributor
    [HttpPost]
    public async Task<ActionResult<Contributor>> Create(Contributor contributor)
    {
        _context.Contributors.Add(contributor);
        await _context.SaveChangesAsync();

        return Ok(contributor);
    }
}
