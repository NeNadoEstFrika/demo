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
    public class UslugiController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UslugiController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Uslugi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uslugi>>> GetUslugi()
        {
            return await _context.Uslugi.ToListAsync();
        }

        // GET: api/Uslugi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uslugi>> GetUslugi(int id)
        {
            var uslugi = await _context.Uslugi.FindAsync(id);

            if (uslugi == null)
            {
                return NotFound();
            }

            return uslugi;
        }

        // PUT: api/Uslugi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUslugi(int id, Uslugi uslugi)
        {
            if (id != uslugi.Id_Uslugi)
            {
                return BadRequest();
            }

            _context.Entry(uslugi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UslugiExists(id))
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

        // POST: api/Uslugi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Uslugi>> PostUslugi(Uslugi uslugi)
        {
            _context.Uslugi.Add(uslugi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUslugi", new { id = uslugi.Id_Uslugi }, uslugi);
        }

        // DELETE: api/Uslugi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Uslugi>> DeleteUslugi(int id)
        {
            var uslugi = await _context.Uslugi.FindAsync(id);
            if (uslugi == null)
            {
                return NotFound();
            }

            _context.Uslugi.Remove(uslugi);
            await _context.SaveChangesAsync();

            return uslugi;
        }

        private bool UslugiExists(int id)
        {
            return _context.Uslugi.Any(e => e.Id_Uslugi == id);
        }
    }
}
