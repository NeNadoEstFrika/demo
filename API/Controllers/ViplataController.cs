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
    public class ViplataController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ViplataController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Viplata
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viplata>>> GetViplata()
        {
            return await _context.Viplata.ToListAsync();
        }

        // GET: api/Viplata/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viplata>> GetViplata(int id)
        {
            var viplata = await _context.Viplata.FindAsync(id);

            if (viplata == null)
            {
                return NotFound();
            }

            return viplata;
        }

        // PUT: api/Viplata/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViplata(int id, Viplata viplata)
        {
            if (id != viplata.Id_Viplati)
            {
                return BadRequest();
            }

            _context.Entry(viplata).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViplataExists(id))
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

        // POST: api/Viplata
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Viplata>> PostViplata(Viplata viplata)
        {
            _context.Viplata.Add(viplata);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViplata", new { id = viplata.Id_Viplati }, viplata);
        }

        // DELETE: api/Viplata/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Viplata>> DeleteViplata(int id)
        {
            var viplata = await _context.Viplata.FindAsync(id);
            if (viplata == null)
            {
                return NotFound();
            }

            _context.Viplata.Remove(viplata);
            await _context.SaveChangesAsync();

            return viplata;
        }

        private bool ViplataExists(int id)
        {
            return _context.Viplata.Any(e => e.Id_Viplati == id);
        }
    }
}
