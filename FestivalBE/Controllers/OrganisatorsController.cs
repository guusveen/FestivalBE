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
    public class OrganisatorsController : ControllerBase
    {
        private readonly FestiFactDbContext _context;

        public OrganisatorsController(FestiFactDbContext context)
        {
            _context = context;
        }

        // GET: api/Organisators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organisator>>> GetOrganisators()
        {
            if (_context.Organisators == null)
            {
                return NotFound();
            }
            
            return await _context.Organisators.ToListAsync();
        }

        // GET: api/Organisators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organisator>> GetOrganisator(int id)
        {
          if (_context.Organisators == null)
          {
              return NotFound();
          }
            var organisator = await _context.Organisators.FindAsync(id);

            if (organisator == null)
            {
                return NotFound();
            }

            return organisator;
        }

        // PUT: api/Organisators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganisator(int id, Organisator organisator)
        {
            if (id != organisator.Id)
            {
                return BadRequest();
            }

            _context.Entry(organisator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganisatorExists(id))
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

        // POST: api/Organisators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organisator>> PostOrganisator(Organisator organisator)
        {
            if (_context.Organisators == null)
            {
                return Problem("Entity set 'FestiFactDbContext.Organisators'  is null.");
            }
            _context.Organisators.Add(organisator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganisator", new { id = organisator.Id }, organisator);
        }

        // DELETE: api/Organisators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganisator(int id)
        {
            if (_context.Organisators == null)
            {
                return NotFound();
            }
            var organisator = await _context.Organisators.FindAsync(id);
            if (organisator == null)
            {
                return NotFound();
            }

            _context.Organisators.Remove(organisator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganisatorExists(int id)
        {
            return (_context.Organisators?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
