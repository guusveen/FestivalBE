using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FestivalBE.Models;
using Microsoft.CodeAnalysis;

namespace FestivalBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalsController : ControllerBase
    {
        private readonly FestiFactDbContext _context;

        public FestivalsController(FestiFactDbContext context)
        {
            _context = context;
        }

        // GET: api/Festivals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festival>>> GetFestivals()
        {
          if (_context.Festivals == null)
          {
              return NotFound();
          }
            return await _context.Festivals.Include(f => f.Locaties)
                .ThenInclude(l => l.Zalen)
            .Include(f => f.Voorstellingen)
                .ThenInclude(v => v.Ratings)
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Festival>> GetFestival(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festival = await _context.Festivals
                .Include(f => f.Locaties)
                    .ThenInclude(locatie => locatie.Zalen)
                        .ThenInclude(zaal => zaal.Voorstellingen)
                .Include(f => f.Voorstellingen)
                    .ThenInclude(V => V.Zaal)
                .Include(f => f.Voorstellingen)
                    .ThenInclude(voorstelling => voorstelling.Ratings)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (festival == null)
            {
                return NotFound();
            }

            return festival;
        }


        // PUT: api/Festivals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFestival(int? id, Festival festival)
        {
            if (id != festival.Id)
            {
                return BadRequest();
            }

            // Get the existing festival from the database
            var existingFestival = await _context.Festivals
                .Include(f => f.Locaties) // Include the existing locaties
                .FirstOrDefaultAsync(f => f.Id == id);

            if (existingFestival == null)
            {
                return NotFound();
            }

            // Update the properties of the existing festival with the new values
            existingFestival.Naam = festival.Naam;
            existingFestival.Beschrijving = festival.Beschrijving;
            existingFestival.BannerAfbeelding = festival.BannerAfbeelding;
            existingFestival.Type = festival.Type;
            existingFestival.Genre = festival.Genre;
            existingFestival.LeeftijdscategorieVan = festival.LeeftijdscategorieVan;
            existingFestival.LeeftijdscategorieTot = festival.LeeftijdscategorieTot;
            existingFestival.StartDatum = festival.StartDatum;
            existingFestival.EindDatum = festival.EindDatum;

            // Remove locaties that are no longer selected
            var removedLocaties = existingFestival.Locaties
                .Where(locatie => !festival.Locaties.Any(l => l.Id == locatie.Id))
                .ToList();
            foreach (var removedLocatie in removedLocaties)
            {
                existingFestival.Locaties.Remove(removedLocatie);
            }

            // Add newly selected locaties
            foreach (var newLocatie in festival.Locaties)
            {
                if (!existingFestival.Locaties.Any(l => l.Id == newLocatie.Id))
                {
                    existingFestival.Locaties.Add(newLocatie);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestivalExists(id))
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


        // POST: api/Festivals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Festival>> PostFestival(Festival festival)
        {
          if (_context.Festivals == null)
          {
              return Problem("Entity set 'FestiFactDbContext.Festivals'  is null.");
          }
            _context.Festivals.Add(festival);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFestival", new { id = festival.Id }, festival);
        }

        // DELETE: api/Festivals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFestival(int? id)
        {
            if (_context.Festivals == null)
            {
                return NotFound();
            }
            var festival = await _context.Festivals.FindAsync(id);
            if (festival == null)
            {
                return NotFound();
            }

            _context.Festivals.Remove(festival);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FestivalExists(int? id)
        {
            return (_context.Festivals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
