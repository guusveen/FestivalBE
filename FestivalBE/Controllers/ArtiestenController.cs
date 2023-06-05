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
    public class ArtiestenController : ControllerBase
    {
        private readonly FestiFactDbContext _context;

        public ArtiestenController(FestiFactDbContext context)
        {
            _context = context;
        }

        // GET: api/Artiesten
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artiest>>> GetArtiesten()
        {
          if (_context.Artiesten == null)
          {
              return NotFound();
          }
            return await _context.Artiesten.ToListAsync();
        }

        // GET: api/Artiesten/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artiest>> GetArtiest(int id)
        {
          if (_context.Artiesten == null)
          {
              return NotFound();
          }
            var artiest = await _context.Artiesten.FindAsync(id);

            if (artiest == null)
            {
                return NotFound();
            }

            return artiest;
        }

        // GET: api/Artiesten/AvailableArtiesten/{voorstellingId}
        [HttpGet("AvailableArtiesten/{voorstellingId}")]
        public async Task<ActionResult<IEnumerable<Artiest>>> GetAvailableArtiesten(int voorstellingId)
        {
            var voorstelling = await _context.Voorstellingen.FindAsync(voorstellingId);

            if (voorstelling == null)
            {
                return NotFound();
            }

            // Get the artists who have no other voorstellingen at the same time
            var availableArtiesten = await _context.Artiesten
                .Where(artiest => artiest.Voorstellingen.All(v => v.StartTijd >= voorstelling.EindTijd || v.EindTijd <= voorstelling.StartTijd))
                .ToListAsync();

            return availableArtiesten;
        }


        // PUT: api/Artiesten/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtiest(int id, Artiest artiest)
        {
            if (id != artiest.Id)
            {
                return BadRequest();
            }

            _context.Entry(artiest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtiestExists(id))
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

        // POST: api/Artiesten
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artiest>> PostArtiest(Artiest artiest)
        {
          if (_context.Artiesten == null)
          {
              return Problem("Entity set 'FestiFactDbContext.Artiesten'  is null.");
          }
            _context.Artiesten.Add(artiest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtiest", new { id = artiest.Id }, artiest);
        }

        // DELETE: api/Artiesten/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtiest(int id)
        {
            if (_context.Artiesten == null)
            {
                return NotFound();
            }
            var artiest = await _context.Artiesten.FindAsync(id);
            if (artiest == null)
            {
                return NotFound();
            }

            _context.Artiesten.Remove(artiest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtiestExists(int id)
        {
            return (_context.Artiesten?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
