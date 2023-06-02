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
    public class ZaalsController : ControllerBase
    {
        private readonly FestiFactDbContext _context;

        public ZaalsController(FestiFactDbContext context)
        {
            _context = context;
        }

        // GET: api/Zaals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zaal>>> GetZalen()
        {
          if (_context.Zalen == null)
          {
              return NotFound();
          }
            return await _context.Zalen.ToListAsync();
        }

        // GET: api/Zaals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zaal>> GetZaal(int id)
        {
          if (_context.Zalen == null)
          {
              return NotFound();
          }
            var zaal = await _context.Zalen.FindAsync(id);

            if (zaal == null)
            {
                return NotFound();
            }

            return zaal;
        }

        // PUT: api/Zaals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZaal(int id, Zaal zaal)
        {
            if (id != zaal.Id)
            {
                return BadRequest();
            }

            _context.Entry(zaal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZaalExists(id))
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

        // POST: api/Zaals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zaal>> PostZaal(Zaal zaal)
        {
          if (_context.Zalen == null)
          {
              return Problem("Entity set 'FestiFactDbContext.Zalen'  is null.");
          }
            _context.Zalen.Add(zaal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZaal", new { id = zaal.Id }, zaal);
        }

        // DELETE: api/Zaals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZaal(int id)
        {
            if (_context.Zalen == null)
            {
                return NotFound();
            }
            var zaal = await _context.Zalen.FindAsync(id);
            if (zaal == null)
            {
                return NotFound();
            }

            _context.Zalen.Remove(zaal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZaalExists(int id)
        {
            return (_context.Zalen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
