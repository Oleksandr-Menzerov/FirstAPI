using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RockersAPI.Models;

namespace RockersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RockersController : ControllerBase
    {
        private readonly FirstAPIContext _context;

        public RockersController(FirstAPIContext context)
        {
            _context = context;
        }

        // GET: api/Rockers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rocker>>> GetRockers()
        {
            if (_context.Rockers == null)
            {
                return NotFound();
            }
            return await _context.Rockers.ToListAsync();
        }

        // GET: api/Rockers/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Rocker>> GetRocker(long id)
        {
            if (_context.Rockers == null)
            {
                return NotFound();
            }
            var rocker = await _context.Rockers.FindAsync(id);

            if (rocker == null)
            {
                return NotFound();
            }

            return rocker;
        }

        // PUT: api/Rockers/id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRocker(long id, Rocker rocker)
        {
            if (id != rocker.Id)
            {
                return BadRequest();
            }

            _context.Entry(rocker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RockerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(rocker);
        }

        // PATCH: api/Rockers/id
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchRocker(long id, Rocker updRocker)
        {
            if (_context.Rockers == null)
            {
                return NotFound();
            }
            var rocker = await _context.Rockers.FindAsync(id);

            if (rocker == null)
            {
                return NotFound();
            }

            if (id != rocker.Id)
            {
                return BadRequest();
            }

            if (updRocker.Name != null && updRocker.Name != rocker.Name)
            {
                rocker.Name = updRocker.Name;
            }

            if (updRocker.Band != null && updRocker.Band != rocker.Band)
            {
                rocker.Band = updRocker.Band;
            }

            _context.Entry(rocker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RockerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(rocker);
        }

        // POST: api/Rockers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rocker>> PostRocker(Rocker rocker)
        {
            if (_context.Rockers == null)
            {
                return Problem("Entity set 'FirstAPIContext.Rockers'  is null.");
            }
            _context.Rockers.Add(rocker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRocker", new { id = rocker.Id }, rocker);
        }

        // DELETE: api/Rockers/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRocker(long id)
        {
            var rocker = await _context.Rockers.FindAsync(id);
            if (rocker == null)
            {
                return NotFound();
            }

            _context.Rockers.Remove(rocker);
            await _context.SaveChangesAsync();

            return Ok($"Rocker with id '{id}' successfully deleted!");
        }

        private bool RockerExists(long id)
        {
            return (_context.Rockers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
