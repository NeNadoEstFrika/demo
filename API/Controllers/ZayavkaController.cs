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
    public class ZayavkaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ZayavkaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Zayavka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zayavka>>> GetZayavka()
        {
            return await _context.Zayavka.ToListAsync();
        }

        // GET: api/Zayavka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zayavka>> GetZayavka(int id)
        {
            var zayavka = await _context.Zayavka.FindAsync(id);

            if (zayavka == null)
            {
                return NotFound();
            }

            return zayavka;
        }

        // PUT: api/Zayavka/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZayavka(int id, Zayavka zayavka)
        {
            if (id != zayavka.Id_Zayavki)
            {
                return BadRequest();
            }

            _context.Entry(zayavka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZayavkaExists(id))
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

        // POST: api/Zayavka
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Zayavka>> PostZayavka(Zayavka zayavka)
        {
            _context.Zayavka.Add(zayavka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZayavka", new { id = zayavka.Id_Zayavki }, zayavka);
        }

        // DELETE: api/Zayavka/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zayavka>> DeleteZayavka(int id)
        {
            var zayavka = await _context.Zayavka.FindAsync(id);
            if (zayavka == null)
            {
                return NotFound();
            }

            _context.Zayavka.Remove(zayavka);
            await _context.SaveChangesAsync();

            return zayavka;
        }

        private bool ZayavkaExists(int id)
        {
            return _context.Zayavka.Any(e => e.Id_Zayavki == id);
        }
    }
}
