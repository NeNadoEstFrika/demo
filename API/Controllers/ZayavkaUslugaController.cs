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
    public class ZayavkaUslugaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ZayavkaUslugaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ZayavkaUsluga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZayavkaUsluga>>> GetZayavkaUsluga_1()
        {
            return await _context.ZayavkaUsluga_1.ToListAsync();
        }

        // GET: api/ZayavkaUsluga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZayavkaUsluga>> GetZayavkaUsluga(int id)
        {
            var zayavkaUsluga = await _context.ZayavkaUsluga_1.FindAsync(id);

            if (zayavkaUsluga == null)
            {
                return NotFound();
            }

            return zayavkaUsluga;
        }

        // PUT: api/ZayavkaUsluga/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZayavkaUsluga(int id, ZayavkaUsluga zayavkaUsluga)
        {
            if (id != zayavkaUsluga.Id_Zayavki)
            {
                return BadRequest();
            }

            _context.Entry(zayavkaUsluga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZayavkaUslugaExists(id))
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

        // POST: api/ZayavkaUsluga
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ZayavkaUsluga>> PostZayavkaUsluga(ZayavkaUsluga zayavkaUsluga)
        {
            _context.ZayavkaUsluga_1.Add(zayavkaUsluga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZayavkaUsluga", new { id = zayavkaUsluga.Id_Zayavki }, zayavkaUsluga);
        }

        // DELETE: api/ZayavkaUsluga/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ZayavkaUsluga>> DeleteZayavkaUsluga(int id)
        {
            var zayavkaUsluga = await _context.ZayavkaUsluga_1.FindAsync(id);
            if (zayavkaUsluga == null)
            {
                return NotFound();
            }

            _context.ZayavkaUsluga_1.Remove(zayavkaUsluga);
            await _context.SaveChangesAsync();

            return zayavkaUsluga;
        }

        private bool ZayavkaUslugaExists(int id)
        {
            return _context.ZayavkaUsluga_1.Any(e => e.Id_Zayavki == id);
        }
    }
}
