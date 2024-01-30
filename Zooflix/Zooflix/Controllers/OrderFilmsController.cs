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
    public class OrderFilmsController : ControllerBase
    {
        private readonly ZooflixContext _context;

        public OrderFilmsController(ZooflixContext context)
        {
            _context = context;
        }

        // GET: api/OrderFilms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderFilm>>> GetOrderFilm()
        {
          if (_context.OrderFilm == null)
          {
              return NotFound();
          }
            return await _context.OrderFilm.ToListAsync();
        }

        // GET: api/OrderFilms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderFilm>> GetOrderFilm(int id)
        {
          if (_context.OrderFilm == null)
          {
              return NotFound();
          }
            var orderFilm = await _context.OrderFilm.FindAsync(id);

            if (orderFilm == null)
            {
                return NotFound();
            }

            return orderFilm;
        }

        // PUT: api/OrderFilms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderFilm(int id, OrderFilm orderFilm)
        {
            if (id != orderFilm.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(orderFilm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderFilmExists(id))
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

        // POST: api/OrderFilms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderFilm>> PostOrderFilm(OrderFilm orderFilm)
        {
          if (_context.OrderFilm == null)
          {
              return Problem("Entity set 'ZooflixContext.OrderFilm'  is null.");
          }
            _context.OrderFilm.Add(orderFilm);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderFilmExists(orderFilm.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderFilm", new { id = orderFilm.OrderId }, orderFilm);
        }

        // DELETE: api/OrderFilms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderFilm(int id)
        {
            if (_context.OrderFilm == null)
            {
                return NotFound();
            }
            var orderFilm = await _context.OrderFilm.FindAsync(id);
            if (orderFilm == null)
            {
                return NotFound();
            }

            _context.OrderFilm.Remove(orderFilm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderFilmExists(int id)
        {
            return (_context.OrderFilm?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
