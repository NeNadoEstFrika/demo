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
    public class CorabliController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CorabliController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Corabli
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Corabli>>> GetCorabli()
        {
            return await _context.Corabli.ToListAsync();
        }

        // GET: api/Corabli/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Corabli>> GetCorabli(int id)
        {
            var corabli = await _context.Corabli.FindAsync(id);

            if (corabli == null)
            {
                return NotFound();
            }

            return corabli;
        }

        // PUT: api/Corabli/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorabli(int id, Corabli corabli)
        {
            if (id != corabli.Id_Corabla)
            {
                return BadRequest();
            }

            _context.Entry(corabli).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorabliExists(id))
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

        // POST: api/Corabli
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Corabli>> PostCorabli(Corabli corabli)
        {
            _context.Corabli.Add(corabli);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCorabli", new { id = corabli.Id_Corabla }, corabli);
        }

        // DELETE: api/Corabli/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Corabli>> DeleteCorabli(int id)
        {
            var corabli = await _context.Corabli.FindAsync(id);
            if (corabli == null)
            {
                return NotFound();
            }

            _context.Corabli.Remove(corabli);
            await _context.SaveChangesAsync();

            return corabli;
        }

        private bool CorabliExists(int id)
        {
            return _context.Corabli.Any(e => e.Id_Corabla == id);
        }
    }
}
