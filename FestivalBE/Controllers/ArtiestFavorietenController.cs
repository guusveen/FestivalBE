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
    public class ArtiestFavorietenController : ControllerBase
    {
        private readonly FestiFactDbContext _context;

        public ArtiestFavorietenController(FestiFactDbContext context)
        {
            _context = context;
        }

        // GET: api/ArtiestFavorieten
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtiestFavoriet>>> GetArtiestFavorieten()
        {
          if (_context.ArtiestFavorieten == null)
          {
              return NotFound();
          }
            return await _context.ArtiestFavorieten.ToListAsync();
        }

        // GET: api/ArtiestFavorieten/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtiestFavoriet>> GetArtiestFavoriet(int? id)
        {
          if (_context.ArtiestFavorieten == null)
          {
              return NotFound();
          }
            var artiestFavoriet = await _context.ArtiestFavorieten.FindAsync(id);

            if (artiestFavoriet == null)
            {
                return NotFound();
            }

            return artiestFavoriet;
        }

        // GET: api/ArtiestFavorieten/FavoriteArtiesten/{bezoekerId}
        [HttpGet("FavoriteArtiesten/{bezoekerId}")]
        public async Task<ActionResult<IEnumerable<Artiest>>> GetFavoriteArtiesten(int bezoekerId)
        {
            var artiestFavorieten = await _context.ArtiestFavorieten
                .Where(af => af.BezoekerId == bezoekerId)
                .Include(af => af.Artiest)
                .Select(af => af.Artiest)
                .ToListAsync();

            return artiestFavorieten;
        }

        // PUT: api/ArtiestFavorieten/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtiestFavoriet(int? id, ArtiestFavoriet artiestFavoriet)
        {
            if (id != artiestFavoriet.Id)
            {
                return BadRequest();
            }

            _context.Entry(artiestFavoriet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtiestFavorietExists(id))
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

        // POST: api/ArtiestFavorieten
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtiestFavoriet>> PostArtiestFavoriet(ArtiestFavoriet artiestFavoriet)
        {
          if (_context.ArtiestFavorieten == null)
          {
              return Problem("Entity set 'FestiFactDbContext.ArtiestFavorieten'  is null.");
          }
            _context.ArtiestFavorieten.Add(artiestFavoriet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtiestFavoriet", new { id = artiestFavoriet.Id }, artiestFavoriet);
        }

        // DELETE: api/ArtiestFavorieten/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtiestFavoriet(int? id)
        {
            if (_context.ArtiestFavorieten == null)
            {
                return NotFound();
            }
            var artiestFavoriet = await _context.ArtiestFavorieten.FindAsync(id);
            if (artiestFavoriet == null)
            {
                return NotFound();
            }

            _context.ArtiestFavorieten.Remove(artiestFavoriet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ArtiestFavorieten/{bezoekerId}/{artiestId}
        [HttpDelete("{bezoekerId}/{artiestId}")]
        public async Task<IActionResult> DeleteArtiestFavoriet(int bezoekerId, int artiestId)
        {
            if (_context.ArtiestFavorieten == null)
            {
                return NotFound();
            }

            var artiestFavoriet = await _context.ArtiestFavorieten.FirstOrDefaultAsync(af => af.BezoekerId == bezoekerId && af.ArtiestId == artiestId);
            if (artiestFavoriet == null)
            {
                return NotFound();
            }

            _context.ArtiestFavorieten.Remove(artiestFavoriet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("HasFavorite/{bezoekerId}/{artiestId}")]
        public async Task<ActionResult<bool>> HasFavorite(int bezoekerId, int artiestId)
        {
            var artiestFavoriet = await _context.ArtiestFavorieten.FirstOrDefaultAsync(af => af.BezoekerId == bezoekerId && af.ArtiestId == artiestId);
            return artiestFavoriet != null;
        }

        private bool ArtiestFavorietExists(int? id)
        {
            return (_context.ArtiestFavorieten?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
