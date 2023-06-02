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
    public class VoorstellingsController : ControllerBase
    {
        private readonly FestiFactDbContext _context;

        public VoorstellingsController(FestiFactDbContext context)
        {
            _context = context;
        }

        // GET: api/Voorstellings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voorstelling>>> GetVoorstellingen()
        {
          if (_context.Voorstellingen == null)
          {
              return NotFound();
          }
            return await _context.Voorstellingen.ToListAsync();
        }

        // GET: api/Voorstellings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voorstelling>> GetVoorstelling(int id)
        {
          if (_context.Voorstellingen == null)
          {
              return NotFound();
          }
            var voorstelling = await _context.Voorstellingen.FindAsync(id);

            if (voorstelling == null)
            {
                return NotFound();
            }

            return voorstelling;
        }

        // PUT: api/Voorstellings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoorstelling(int id, Voorstelling voorstelling)
        {
            if (id != voorstelling.Id)
            {
                return BadRequest();
            }

            _context.Entry(voorstelling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoorstellingExists(id))
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

        // POST: api/Voorstellings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voorstelling>> PostVoorstelling(Voorstelling voorstelling)
        {
          if (_context.Voorstellingen == null)
          {
              return Problem("Entity set 'FestiFactDbContext.Voorstellingen'  is null.");
          }
            _context.Voorstellingen.Add(voorstelling);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoorstelling", new { id = voorstelling.Id }, voorstelling);
        }

        // DELETE: api/Voorstellings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoorstelling(int id)
        {
            if (_context.Voorstellingen == null)
            {
                return NotFound();
            }
            var voorstelling = await _context.Voorstellingen.FindAsync(id);
            if (voorstelling == null)
            {
                return NotFound();
            }

            _context.Voorstellingen.Remove(voorstelling);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoorstellingExists(int id)
        {
            return (_context.Voorstellingen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
