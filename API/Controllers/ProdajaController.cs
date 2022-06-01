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
    public class ProdajaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ProdajaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Prodaja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prodaja>>> GetProdaja()
        {
            return await _context.Prodaja.ToListAsync();
        }

        // GET: api/Prodaja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prodaja>> GetProdaja(int id)
        {
            var prodaja = await _context.Prodaja.FindAsync(id);

            if (prodaja == null)
            {
                return NotFound();
            }

            return prodaja;
        }

        // PUT: api/Prodaja/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdaja(int id, Prodaja prodaja)
        {
            if (id != prodaja.Id_Prodaji)
            {
                return BadRequest();
            }

            _context.Entry(prodaja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdajaExists(id))
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

        // POST: api/Prodaja
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Prodaja>> PostProdaja(Prodaja prodaja)
        {
            _context.Prodaja.Add(prodaja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdaja", new { id = prodaja.Id_Prodaji }, prodaja);
        }

        // DELETE: api/Prodaja/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prodaja>> DeleteProdaja(int id)
        {
            var prodaja = await _context.Prodaja.FindAsync(id);
            if (prodaja == null)
            {
                return NotFound();
            }

            _context.Prodaja.Remove(prodaja);
            await _context.SaveChangesAsync();

            return prodaja;
        }

        private bool ProdajaExists(int id)
        {
            return _context.Prodaja.Any(e => e.Id_Prodaji == id);
        }
    }
}
