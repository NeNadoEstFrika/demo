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
    public class ZarplataController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ZarplataController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Zarplata
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zarplata>>> GetZarplata()
        {
            return await _context.Zarplata.ToListAsync();
        }

        // GET: api/Zarplata/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zarplata>> GetZarplata(int id)
        {
            var zarplata = await _context.Zarplata.FindAsync(id);

            if (zarplata == null)
            {
                return NotFound();
            }

            return zarplata;
        }

        // PUT: api/Zarplata/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZarplata(int id, Zarplata zarplata)
        {
            if (id != zarplata.Id_Zarplata)
            {
                return BadRequest();
            }

            _context.Entry(zarplata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZarplataExists(id))
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

        // POST: api/Zarplata
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Zarplata>> PostZarplata(Zarplata zarplata)
        {
            _context.Zarplata.Add(zarplata);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZarplata", new { id = zarplata.Id_Zarplata }, zarplata);
        }

        // DELETE: api/Zarplata/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zarplata>> DeleteZarplata(int id)
        {
            var zarplata = await _context.Zarplata.FindAsync(id);
            if (zarplata == null)
            {
                return NotFound();
            }

            _context.Zarplata.Remove(zarplata);
            await _context.SaveChangesAsync();

            return zarplata;
        }

        private bool ZarplataExists(int id)
        {
            return _context.Zarplata.Any(e => e.Id_Zarplata == id);
        }
    }
}
