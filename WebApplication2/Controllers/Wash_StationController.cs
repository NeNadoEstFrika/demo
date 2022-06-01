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
    public class Wash_StationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Wash_StationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Wash_Station
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wash_Station>>> GetWash_Station()
        {
            return await _context.Wash_Station.ToListAsync();
        }

        // GET: api/Wash_Station/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wash_Station>> GetWash_Station(int id)
        {
            var wash_Station = await _context.Wash_Station.FindAsync(id);

            if (wash_Station == null)
            {
                return NotFound();
            }

            return wash_Station;
        }

        // PUT: api/Wash_Station/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWash_Station(int id, Wash_Station wash_Station)
        {
            if (id != wash_Station.id_Station)
            {
                return BadRequest();
            }

            _context.Entry(wash_Station).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Wash_StationExists(id))
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

        // POST: api/Wash_Station
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wash_Station>> PostWash_Station(Wash_Station wash_Station)
        {
            _context.Wash_Station.Add(wash_Station);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWash_Station", new { id = wash_Station.id_Station }, wash_Station);
        }

        // DELETE: api/Wash_Station/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWash_Station(int id)
        {
            var wash_Station = await _context.Wash_Station.FindAsync(id);
            if (wash_Station == null)
            {
                return NotFound();
            }

            _context.Wash_Station.Remove(wash_Station);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Wash_StationExists(int id)
        {
            return _context.Wash_Station.Any(e => e.id_Station == id);
        }
    }
}
