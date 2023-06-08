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
    public class VoorstellingFavorietenController : ControllerBase
    {
        private readonly FestiFactDbContext _context;

        public VoorstellingFavorietenController(FestiFactDbContext context)
        {
            _context = context;
        }

        // GET: api/VoorstellingFavorieten
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoorstellingFavoriet>>> GetVoorstellingFavorieten()
        {
          if (_context.VoorstellingFavorieten == null)
          {
              return NotFound();
          }
            return await _context.VoorstellingFavorieten.ToListAsync();
        }

        // GET: api/VoorstellingFavorieten/FavoriteVoorstellingen/{Id}
        [HttpGet("FavoriteVoorstellingen/{Id}")]
        public async Task<ActionResult<List<Voorstelling>>> GetFavoriteVoorstellingen(string Id)
        {
            int bezoekerId;
            if (!int.TryParse(Id, out bezoekerId))
            {
                return BadRequest();
            }

            var favoriteVoorstellingen = await _context.VoorstellingFavorieten
                .Include(f => f.Voorstelling)
                    .ThenInclude(v => v.Zaal)
                        .ThenInclude(z => z.Locatie)
                .Where(f => f.BezoekerId == bezoekerId)
                .Select(f => f.Voorstelling)
                .ToListAsync();

            return favoriteVoorstellingen;
        }

        // GET: api/VoorstellingFavorieten/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VoorstellingFavoriet>> GetVoorstellingFavoriet(int? id)
        {
          if (_context.VoorstellingFavorieten == null)
          {
              return NotFound();
          }
            var voorstellingFavoriet = await _context.VoorstellingFavorieten.FindAsync(id);

            if (voorstellingFavoriet == null)
            {
                return NotFound();
            }

            return voorstellingFavoriet;
        }

        // PUT: api/VoorstellingFavorieten/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoorstellingFavoriet(int? id, VoorstellingFavoriet voorstellingFavoriet)
        {
            if (id != voorstellingFavoriet.Id)
            {
                return BadRequest();
            }

            _context.Entry(voorstellingFavoriet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoorstellingFavorietExists(id))
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

        // POST: api/VoorstellingFavorieten
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VoorstellingFavoriet>> PostVoorstellingFavoriet(VoorstellingFavoriet voorstellingFavoriet)
        {
          if (_context.VoorstellingFavorieten == null)
          {
              return Problem("Entity set 'FestiFactDbContext.VoorstellingFavorieten'  is null.");
          }
            _context.VoorstellingFavorieten.Add(voorstellingFavoriet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoorstellingFavoriet", new { id = voorstellingFavoriet.Id }, voorstellingFavoriet);
        }

        // DELETE: api/VoorstellingFavorieten/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoorstellingFavoriet(int? id)
        {
            if (_context.VoorstellingFavorieten == null)
            {
                return NotFound();
            }
            var voorstellingFavoriet = await _context.VoorstellingFavorieten.FindAsync(id);
            if (voorstellingFavoriet == null)
            {
                return NotFound();
            }

            _context.VoorstellingFavorieten.Remove(voorstellingFavoriet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/VoorstellingFavorieten/{bezoekerId}/{voorstellingId}
        [HttpDelete("{bezoekerId}/{voorstellingId}")]
        public async Task<IActionResult> DeleteVoorstellingFavoriet(int bezoekerId, int voorstellingId)
        {
            var voorstellingFavoriet = await _context.VoorstellingFavorieten
                .FirstOrDefaultAsync(f => f.BezoekerId == bezoekerId && f.VoorstellingId == voorstellingId);

            if (voorstellingFavoriet == null)
            {
                return NotFound();
            }

            _context.VoorstellingFavorieten.Remove(voorstellingFavoriet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoorstellingFavorietExists(int? id)
        {
            return (_context.VoorstellingFavorieten?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: api/VoorstellingFavorieten/HasFavorite
        [HttpGet("HasFavorite/{bezoekerId}/{voorstellingId}")]
        public bool HasFavorite(int bezoekerId, int voorstellingId)
        {
            var voorstellingfavorieten = _context.VoorstellingFavorieten.Any(f => f.BezoekerId == bezoekerId && f.VoorstellingId == voorstellingId);
            return voorstellingfavorieten;
        }
    }
}
