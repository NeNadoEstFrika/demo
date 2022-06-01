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
    public class Okazanie_uslugiController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Okazanie_uslugiController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Okazanie_uslugi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Okazanie_uslugi>>> GetOkazanie_Uslugi()
        {
            return await _context.Okazanie_Uslugi.ToListAsync();
        }

        // GET: api/Okazanie_uslugi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Okazanie_uslugi>> GetOkazanie_uslugi(int id)
        {
            var okazanie_uslugi = await _context.Okazanie_Uslugi.FindAsync(id);

            if (okazanie_uslugi == null)
            {
                return NotFound();
            }

            return okazanie_uslugi;
        }

        // PUT: api/Okazanie_uslugi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOkazanie_uslugi(int id, Okazanie_uslugi okazanie_uslugi)
        {
            if (id != okazanie_uslugi.IdCheka)
            {
                return BadRequest();
            }

            _context.Entry(okazanie_uslugi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Okazanie_uslugiExists(id))
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

        // POST: api/Okazanie_uslugi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Okazanie_uslugi>> PostOkazanie_uslugi(Okazanie_uslugi okazanie_uslugi)
        {
            _context.Okazanie_Uslugi.Add(okazanie_uslugi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOkazanie_uslugi", new { id = okazanie_uslugi.IdCheka }, okazanie_uslugi);
        }

        // DELETE: api/Okazanie_uslugi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Okazanie_uslugi>> DeleteOkazanie_uslugi(int id)
        {
            var okazanie_uslugi = await _context.Okazanie_Uslugi.FindAsync(id);
            if (okazanie_uslugi == null)
            {
                return NotFound();
            }

            _context.Okazanie_Uslugi.Remove(okazanie_uslugi);
            await _context.SaveChangesAsync();

            return okazanie_uslugi;
        }

        private bool Okazanie_uslugiExists(int id)
        {
            return _context.Okazanie_Uslugi.Any(e => e.IdCheka == id);
        }
    }
}
