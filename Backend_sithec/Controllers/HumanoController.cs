using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_sithec.Context;
using Backend_sithec.Model;

namespace Backend_sithec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HumanoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Humano
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Humano>>> GetHumano()
        {
          if (_context.Humano == null)
          {
              return NotFound();
          }
            return await _context.Humano.ToListAsync();
        }

        // GET: api/Humano/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Humano>> GetHumano(int id)
        {
          if (_context.Humano == null)
          {
              return NotFound();
          }
            var humano = await _context.Humano.FindAsync(id);

            if (humano == null)
            {
                return NotFound();
            }

            return humano;
        }

        // PUT: api/Humano/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHumano(int id, Humano humano)
        {
            if (id != humano.Id)
            {
                return BadRequest();
            }

            _context.Entry(humano).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumanoExists(id))
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

        // POST: api/Humano
        [HttpPost]
        public async Task<ActionResult<Humano>> PostHumano(Humano humano)
        {
          if (_context.Humano == null)
          {
              return Problem("Entity set 'AppDbContext.Humano'  is null.");
          }
            _context.Humano.Add(humano);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHumano", new { id = humano.Id }, humano);
        }

        // DELETE: api/Humano/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHumano(int id)
        {
            if (_context.Humano == null)
            {
                return NotFound();
            }
            var humano = await _context.Humano.FindAsync(id);
            if (humano == null)
            {
                return NotFound();
            }

            _context.Humano.Remove(humano);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HumanoExists(int id)
        {
            return (_context.Humano?.Any(e => e.Id == id)).GetValueOrDefault();
        } 
    }
}
