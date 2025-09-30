using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UrlShorteningService.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class RedirectController : ControllerBase
{
    private readonly RedirectDbContext _db;

    public RedirectController(RedirectDbContext db)
    {
        _db = db;
    }
    [HttpGet("{shortUri}")]
    public async Task<IActionResult> RedirectToLongUrl(string shortUri)
    {
        var entry = await _db.RedirectEntries
                             .FirstOrDefaultAsync(r => r.ShortUri == shortUri);

        if (entry == null)
            return NotFound();

        return RedirectPermanent(entry.LongUrl); // 301 redirect
    }
    [HttpPost]
    public async Task<IActionResult> CreateRedirect(string shortUri, string longUrl)
    {
        var entry = new RedirectEntry
        {
            ShortUri = shortUri,
            LongUrl = longUrl
        };

        _db.RedirectEntries.Add(entry);
        await _db.SaveChangesAsync();

        return Ok(entry);
    }
}

