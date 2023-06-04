using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FestivalBE.Models;

namespace FestivalBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocatiesController : ControllerBase
    {
        private readonly FestiFactDbContext _context;

        public LocatiesController(FestiFactDbContext context)
        {
            _context = context;
        }

        // GET: api/Locaties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locatie>>> GetLocaties()
        {
          if (_context.Locaties == null)
          {
              return NotFound();
          }
            return await _context.Locaties.Include(l => l.Zalen).ToListAsync();
        }

        // GET: api/Locaties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locatie>> GetLocatie(int id)
        {
          if (_context.Locaties == null)
          {
              return NotFound();
          }
            var locatie = await _context.Locaties.FindAsync(id);

            if (locatie == null)
            {
                return NotFound();
            }

            _context.Entry(locatie).Collection(l => l.Zalen).Load();

            return locatie;
        }

        // PUT: api/Locaties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocatie(int id, Locatie locatie)
        {
            if (id != locatie.Id)
            {
                return BadRequest();
            }

            _context.Entry(locatie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocatieExists(id))
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

        // POST: api/Locaties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Locatie>> PostLocatie(Locatie locatie)
        {
          if (_context.Locaties == null)
          {
              return Problem("Entity set 'FestiFactDbContext.Locaties'  is null.");
          }
            _context.Locaties.Add(locatie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocatie", new { id = locatie.Id }, locatie);
        }

        // DELETE: api/Locaties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocatie(int id)
        {
            if (_context.Locaties == null)
            {
                return NotFound();
            }
            var locatie = await _context.Locaties.FindAsync(id);
            if (locatie == null)
            {
                return NotFound();
            }

            _context.Locaties.Remove(locatie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocatieExists(int id)
        {
            return (_context.Locaties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
