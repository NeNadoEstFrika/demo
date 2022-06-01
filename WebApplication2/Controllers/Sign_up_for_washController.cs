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
    public class Sign_up_for_washController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Sign_up_for_washController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Sign_up_for_wash
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sign_up_for_wash>>> Getsign_Up_For_wash()
        {
            return await _context.sign_Up_For_wash.ToListAsync();
        }

        // GET: api/Sign_up_for_wash/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sign_up_for_wash>> GetSign_up_for_wash(int id)
        {
            var sign_up_for_wash = await _context.sign_Up_For_wash.FindAsync(id);

            if (sign_up_for_wash == null)
            {
                return NotFound();
            }

            return sign_up_for_wash;
        }

        // PUT: api/Sign_up_for_wash/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSign_up_for_wash(int id, Sign_up_for_wash sign_up_for_wash)
        {
            if (id != sign_up_for_wash.id_Sign_up)
            {
                return BadRequest();
            }

            _context.Entry(sign_up_for_wash).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sign_up_for_washExists(id))
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

        // POST: api/Sign_up_for_wash
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sign_up_for_wash>> PostSign_up_for_wash(Sign_up_for_wash sign_up_for_wash)
        {
            _context.sign_Up_For_wash.Add(sign_up_for_wash);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSign_up_for_wash", new { id = sign_up_for_wash.id_Sign_up }, sign_up_for_wash);
        }

        // DELETE: api/Sign_up_for_wash/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSign_up_for_wash(int id)
        {
            var sign_up_for_wash = await _context.sign_Up_For_wash.FindAsync(id);
            if (sign_up_for_wash == null)
            {
                return NotFound();
            }

            _context.sign_Up_For_wash.Remove(sign_up_for_wash);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Sign_up_for_washExists(int id)
        {
            return _context.sign_Up_For_wash.Any(e => e.id_Sign_up == id);
        }
    }
}
