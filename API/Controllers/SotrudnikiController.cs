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
    public class SotrudnikiController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public SotrudnikiController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Sotrudniki
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sotrudniki>>> GetSotrudniki()
        {
            return await _context.Sotrudniki.ToListAsync();
        }

        // GET: api/Sotrudniki/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sotrudniki>> GetSotrudniki(int id)
        {
            var sotrudniki = await _context.Sotrudniki.FindAsync(id);

            if (sotrudniki == null)
            {
                return NotFound();
            }

            return sotrudniki;
        }

        // PUT: api/Sotrudniki/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSotrudniki(int id, Sotrudniki sotrudniki)
        {
            if (id != sotrudniki.Id_Sotrudnika)
            {
                return BadRequest();
            }

            _context.Entry(sotrudniki).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SotrudnikiExists(id))
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

        // POST: api/Sotrudniki
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sotrudniki>> PostSotrudniki(Sotrudniki sotrudniki)
        {
            _context.Sotrudniki.Add(sotrudniki);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSotrudniki", new { id = sotrudniki.Id_Sotrudnika }, sotrudniki);
        }

        // DELETE: api/Sotrudniki/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sotrudniki>> DeleteSotrudniki(int id)
        {
            var sotrudniki = await _context.Sotrudniki.FindAsync(id);
            if (sotrudniki == null)
            {
                return NotFound();
            }

            _context.Sotrudniki.Remove(sotrudniki);
            await _context.SaveChangesAsync();

            return sotrudniki;
        }

        private bool SotrudnikiExists(int id)
        {
            return _context.Sotrudniki.Any(e => e.Id_Sotrudnika == id);
        }
    }
}
