using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarwashController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CarwashController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Carwash
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carwash>>> GetCarwash()
        {
            return await _context.Carwash.ToListAsync();
        }

        // GET: api/Carwash/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carwash>> GetCarwash(int id)
        {
            var carwash = await _context.Carwash.FindAsync(id);

            if (carwash == null)
            {
                return NotFound();
            }

            return carwash;
        }

        // PUT: api/Carwash/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarwash(int id, Carwash carwash)
        {
            if (id != carwash.id_carwash)
            {
                return BadRequest();
            }

            _context.Entry(carwash).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarwashExists(id))
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

        // POST: api/Carwash
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carwash>> PostCarwash(Carwash carwash)
        {
            _context.Carwash.Add(carwash);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarwash", new { id = carwash.id_carwash }, carwash);
        }

        // DELETE: api/Carwash/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarwash(int id)
        {
            var carwash = await _context.Carwash.FindAsync(id);
            if (carwash == null)
            {
                return NotFound();
            }

            _context.Carwash.Remove(carwash);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarwashExists(int id)
        {
            return _context.Carwash.Any(e => e.id_carwash == id);
        }
    }
}
