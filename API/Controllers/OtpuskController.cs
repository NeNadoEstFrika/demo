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
    public class OtpuskController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OtpuskController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Otpusk
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Otpusk>>> GetOtpusk()
        {
            return await _context.Otpusk.ToListAsync();
        }

        // GET: api/Otpusk/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Otpusk>> GetOtpusk(int id)
        {
            var otpusk = await _context.Otpusk.FindAsync(id);

            if (otpusk == null)
            {
                return NotFound();
            }

            return otpusk;
        }

        // PUT: api/Otpusk/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOtpusk(int id, Otpusk otpusk)
        {
            if (id != otpusk.Id_Otpuska)
            {
                return BadRequest();
            }

            _context.Entry(otpusk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtpuskExists(id))
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

        // POST: api/Otpusk
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Otpusk>> PostOtpusk(Otpusk otpusk)
        {
            _context.Otpusk.Add(otpusk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOtpusk", new { id = otpusk.Id_Otpuska }, otpusk);
        }

        // DELETE: api/Otpusk/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Otpusk>> DeleteOtpusk(int id)
        {
            var otpusk = await _context.Otpusk.FindAsync(id);
            if (otpusk == null)
            {
                return NotFound();
            }

            _context.Otpusk.Remove(otpusk);
            await _context.SaveChangesAsync();

            return otpusk;
        }

        private bool OtpuskExists(int id)
        {
            return _context.Otpusk.Any(e => e.Id_Otpuska == id);
        }
    }
}
