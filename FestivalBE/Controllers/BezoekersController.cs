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
    public class BezoekersController : ControllerBase
    {
        private readonly FestiFactDbContext _context;

        public BezoekersController(FestiFactDbContext context)
        {
            _context = context;
        }

        // GET: api/Bezoekers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bezoeker>>> GetBezoekers()
        {
          if (_context.Bezoekers == null)
          {
              return NotFound();
          }
            return await _context.Bezoekers.ToListAsync();
        }

        // GET: api/Bezoekers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bezoeker>> GetBezoeker(int id)
        {
          if (_context.Bezoekers == null)
          {
              return NotFound();
          }
            var bezoeker = await _context.Bezoekers.FindAsync(id);

            if (bezoeker == null)
            {
                return NotFound();
            }

            return bezoeker;
        }

        // PUT: api/Bezoekers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBezoeker(int id, Bezoeker bezoeker)
        {
            if (id != bezoeker.Id)
            {
                return BadRequest();
            }

            _context.Entry(bezoeker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BezoekerExists(id))
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

        // POST: api/Bezoekers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bezoeker>> PostBezoeker(Bezoeker bezoeker)
        {
          if (_context.Bezoekers == null)
          {
              return Problem("Entity set 'FestiFactDbContext.Bezoekers'  is null.");
          }
            _context.Bezoekers.Add(bezoeker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBezoeker", new { id = bezoeker.Id }, bezoeker);
        }

        // DELETE: api/Bezoekers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBezoeker(int id)
        {
            if (_context.Bezoekers == null)
            {
                return NotFound();
            }
            var bezoeker = await _context.Bezoekers.FindAsync(id);
            if (bezoeker == null)
            {
                return NotFound();
            }

            _context.Bezoekers.Remove(bezoeker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BezoekerExists(int id)
        {
            return (_context.Bezoekers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
