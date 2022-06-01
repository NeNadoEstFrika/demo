using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrichalController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PrichalController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Prichal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prichal>>> GetPrichal()
        {
            return await _context.Prichal.ToListAsync();
        }

        // GET: api/Prichal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prichal>> GetPrichal(int id)
        {
            var prichal = await _context.Prichal.FindAsync(id);

            if (prichal == null)
            {
                return NotFound();
            }

            return prichal;
        }

        // PUT: api/Prichal/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrichal(int id, Prichal prichal)
        {
            if (id != prichal.Id_Prichala)
            {
                return BadRequest();
            }

            _context.Entry(prichal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrichalExists(id))
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

        // POST: api/Prichal
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Prichal>> PostPrichal(Prichal prichal)
        {
            _context.Prichal.Add(prichal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrichal", new { id = prichal.Id_Prichala }, prichal);
        }

        // DELETE: api/Prichal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prichal>> DeletePrichal(int id)
        {
            var prichal = await _context.Prichal.FindAsync(id);
            if (prichal == null)
            {
                return NotFound();
            }

            _context.Prichal.Remove(prichal);
            await _context.SaveChangesAsync();

            return prichal;
        }

        private bool PrichalExists(int id)
        {
            return _context.Prichal.Any(e => e.Id_Prichala == id);
        }
    }
}
