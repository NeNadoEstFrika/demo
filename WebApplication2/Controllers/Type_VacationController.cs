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
    public class Type_VacationController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public Type_VacationController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Type_Vacation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type_Vacation>>> Gettype_Vacation()
        {
            return await _context.type_Vacation.ToListAsync();
        }

        // GET: api/Type_Vacation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Type_Vacation>> GetType_Vacation(int id)
        {
            var type_Vacation = await _context.type_Vacation.FindAsync(id);

            if (type_Vacation == null)
            {
                return NotFound();
            }

            return type_Vacation;
        }

        // PUT: api/Type_Vacation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType_Vacation(int id, Type_Vacation type_Vacation)
        {
            if (id != type_Vacation.id_type_vacation)
            {
                return BadRequest();
            }

            _context.Entry(type_Vacation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Type_VacationExists(id))
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

        // POST: api/Type_Vacation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Type_Vacation>> PostType_Vacation(Type_Vacation type_Vacation)
        {
            _context.type_Vacation.Add(type_Vacation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType_Vacation", new { id = type_Vacation.id_type_vacation }, type_Vacation);
        }

        // DELETE: api/Type_Vacation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType_Vacation(int id)
        {
            var type_Vacation = await _context.type_Vacation.FindAsync(id);
            if (type_Vacation == null)
            {
                return NotFound();
            }

            _context.type_Vacation.Remove(type_Vacation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Type_VacationExists(int id)
        {
            return _context.type_Vacation.Any(e => e.id_type_vacation == id);
        }
    }
}
