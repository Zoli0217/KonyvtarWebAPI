using KonyvtarWebAPI.Data;
using KonyvtarWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KonyvtarWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonyvAlapController : ControllerBase
    {
       private readonly KonyvtarDbContext _context;
        public KonyvAlapController(KonyvtarDbContext context)
        {
            _context = context;
        }

        // GET: api/<KonyvAlapController>
        [HttpGet]
        public async Task<IList<Konyv>> GetAsync()
        {
            return await _context.Konyvek.ToListAsync();
        }

        // GET api/<KonyvAlapController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Konyv>> GetAsync(int id)
        {
            var keresettKonyv = await _context.Konyvek.FindAsync(id);
            if (keresettKonyv == null)
            {
                return NotFound();
            }
            return Ok(keresettKonyv);
        }

        // POST api/<KonyvAlapController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<KonyvAlapController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KonyvAlapController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
