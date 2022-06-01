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
    public class PayController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public PayController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Pay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pay>>> GetPay()
        {
            return await _context.Pay.ToListAsync();
        }

        // GET: api/Pay/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pay>> GetPay(int id)
        {
            var pay = await _context.Pay.FindAsync(id);

            if (pay == null)
            {
                return NotFound();
            }

            return pay;
        }

        // PUT: api/Pay/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPay(int id, Pay pay)
        {
            if (id != pay.id_Pay)
            {
                return BadRequest();
            }

            _context.Entry(pay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayExists(id))
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

        // POST: api/Pay
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pay>> PostPay(Pay pay)
        {
            _context.Pay.Add(pay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPay", new { id = pay.id_Pay }, pay);
        }

        // DELETE: api/Pay/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePay(int id)
        {
            var pay = await _context.Pay.FindAsync(id);
            if (pay == null)
            {
                return NotFound();
            }

            _context.Pay.Remove(pay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayExists(int id)
        {
            return _context.Pay.Any(e => e.id_Pay == id);
        }
    }
}
