using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zooflix.Data;
using Zooflix.Models;

namespace Zooflix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtoilesController : ControllerBase
    {
        private readonly ZooflixContext _context;

        public EtoilesController(ZooflixContext context)
        {
            _context = context;
        }

        // GET: api/Etoiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etoile>>> GetEtoile()
        {
          if (_context.Etoile == null)
          {
              return NotFound();
          }
            return await _context.Etoile.ToListAsync();
        }

        // GET: api/Etoiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etoile>> GetEtoile(int id)
        {
          if (_context.Etoile == null)
          {
              return NotFound();
          }
            var etoile = await _context.Etoile.FindAsync(id);

            if (etoile == null)
            {
                return NotFound();
            }

            return etoile;
        }

        // PUT: api/Etoiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtoile(int id, Etoile etoile)
        {
            if (id != etoile.Id)
            {
                return BadRequest();
            }

            _context.Entry(etoile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtoileExists(id))
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

        // POST: api/Etoiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Etoile>> PostEtoile(Etoile etoile)
        {
          if (_context.Etoile == null)
          {
              return Problem("Entity set 'ZooflixContext.Etoile'  is null.");
          }
            _context.Etoile.Add(etoile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtoile", new { id = etoile.Id }, etoile);
        }

        // DELETE: api/Etoiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtoile(int id)
        {
            if (_context.Etoile == null)
            {
                return NotFound();
            }
            var etoile = await _context.Etoile.FindAsync(id);
            if (etoile == null)
            {
                return NotFound();
            }

            _context.Etoile.Remove(etoile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtoileExists(int id)
        {
            return (_context.Etoile?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
