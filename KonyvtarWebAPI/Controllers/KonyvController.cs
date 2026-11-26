using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KonyvtarWebAPI.Models;
using KonyvtarWebAPI.Data;
using KonyvtarWebAPI.DTOs;
using Microsoft.AspNetCore.Cors;

[Route("api/[controller]")]
[ApiController]
public class KonyvController : ControllerBase
{
    private readonly KonyvtarDbContext _context;
    public KonyvController(KonyvtarDbContext context)
    {
        _context = context;
    }

    // GET: api/Konyv
    [HttpGet]
    [EnableCors("FrontendPolicy")]
    public async Task<ActionResult<IEnumerable<KonyvGetDTO>>> GetKonyv()
    {
        var konyvek = await _context.Konyvek.Include(k => k.Szerzo)
            .Select(k => new KonyvGetDTO
            {
                Cim = k.Cim,
                KiadasEve = k.KiadasEve,
                SzerzoId = k.SzerzoId,
                SzerzoNev = k.Szerzo.Nev
            })
            .ToListAsync();
        return konyvek;
    }

    // GET: api/Konyv/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Konyv>> GetKonyv(int id)
    {
        var konyv = await _context.Konyvek.FindAsync(id);

        if (konyv == null)
        {
            return NotFound();
        }

        return konyv;
    }

    // PUT: api/Konyv/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutKonyv(int? id, Konyv konyv)
    {
        if (id != konyv.Id)
        {
            return BadRequest();
        }

        _context.Entry(konyv).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!KonyvExists(id))
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

    //PATCH: api/Konyv/5
    //[HttpPatch("{id}")]
 

    // POST: api/Konyv
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Konyv>> PostKonyv(KonyvPostDTO konyv)
    {
        var konyvEntity = new Konyv
        {
            Cim = konyv.Cim,
            KiadasEve = konyv.KiadasEve,
            SzerzoId = konyv.SzerzoId
        };

        _context.Konyvek.Add(konyvEntity);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetKonyv", new { id = konyvEntity.Id }, konyvEntity);
    }

    // DELETE: api/Konyv/5
    [HttpDelete("{id}")]
    [EnableCors("BackendPolicy")]
    public async Task<IActionResult> DeleteKonyv(int? id)
    {
        var konyv = await _context.Konyvek.FindAsync(id);
        if (konyv == null)
        {
            return NotFound();
        }

        _context.Konyvek.Remove(konyv);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("csakfejleszteskor")]
    [DisableCors]

    private bool KonyvExists(int? id)
    {
        return _context.Konyvek.Any(e => e.Id == id);
    }
}
