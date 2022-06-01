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
    public class Wash_userController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Wash_userController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Wash_user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wash_user>>> GetWash_User()
        {
            return await _context.Wash_User.ToListAsync();
        }

        // GET: api/Wash_user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wash_user>> GetWash_user(int id)
        {
            var wash_user = await _context.Wash_User.FindAsync(id);

            if (wash_user == null)
            {
                return NotFound();
            }

            return wash_user;
        }

        // PUT: api/Wash_user/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWash_user(int id, Wash_user wash_user)
        {
            if (id != wash_user.id_User)
            {
                return BadRequest();
            }

            _context.Entry(wash_user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Wash_userExists(id))
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

        // POST: api/Wash_user
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wash_user>> PostWash_user(Wash_user wash_user)
        {
            _context.Wash_User.Add(wash_user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWash_user", new { id = wash_user.id_User }, wash_user);
        }

        // DELETE: api/Wash_user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWash_user(int id)
        {
            var wash_user = await _context.Wash_User.FindAsync(id);
            if (wash_user == null)
            {
                return NotFound();
            }

            _context.Wash_User.Remove(wash_user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Wash_userExists(int id)
        {
            return _context.Wash_User.Any(e => e.id_User == id);
        }
    }
}
