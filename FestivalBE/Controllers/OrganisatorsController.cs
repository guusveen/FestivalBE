using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FestivalBE.Models;
using FestivalBE.Helpers;
using FestivalBE.DTO;

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

        // POST: api/Organisator/Register
        [HttpPost("Register")]
        public async Task<ActionResult<OrganisatorDTO>> Register(Organisator organisator)
        {
            if (_context.Organisators == null)
            {
                return Problem("Entity set 'FestiFactDbContext.Organisators' is null.");
            }

            // Validate the registration model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the email is already registered
            if (_context.Organisators.Any(o => o.Email == organisator.Email))
            {
                return Conflict("Email already registered.");
            }

            // Hash the password
            organisator.Password = PasswordHasher.HashPassword(organisator.Password);

            // Create a new Organisator entity
            _context.Organisators.Add(organisator);
            await _context.SaveChangesAsync();

            // Create an OrganisatorDto without the password
            var organisatorDto = new OrganisatorDTO
            {
                Id = organisator.Id,
                Email = organisator.Email,
                Name = organisator.Name
            };

            return CreatedAtAction("GetOrganisator", new { id = organisatorDto.Id }, organisatorDto);
        }

        // POST: api/Organisator/Login
        [HttpPost("Login")]
        public async Task<ActionResult<OrganisatorDTO>> Login(Organisator organisator)
        {
            if (_context.Organisators == null)
            {
                return Problem("Entity set 'FestiFactDbContext.Organisators' is null.");
            }

            // Retrieve the organisator by email
            var organisatorDb = await _context.Organisators.FirstOrDefaultAsync(o => o.Email == organisator.Email);

            if (organisatorDb == null)
            {
                return NotFound("Organisator not found.");
            }

            // Verify the password
            if (PasswordHasher.HashPassword(organisator.Password) != organisatorDb.Password)
            {
                return Unauthorized("Invalid credentials.");
            }

            // Create an OrganisatorDto without the password
            var organisatorDto = new OrganisatorDTO
            {
                Id = organisatorDb.Id,
                Email = organisatorDb.Email,
                Name = organisatorDb.Name
            };

            return Ok(organisatorDto);
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
