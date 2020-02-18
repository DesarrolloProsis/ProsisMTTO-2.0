using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsisMTTO.Context;
using ProsisMTTO.Entities;

namespace ProsisMTTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DTCInventoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DTCInventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DTCInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTCInventory>>> GetDTCInventories()
        {
            return await _context.DTCInventories.ToListAsync();
        }

        // GET: api/DTCInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTCInventory>> GetDTCInventory(string id)
        {
            var dTCInventory = await _context.DTCInventories.FindAsync(id);

            if (dTCInventory == null)
            {
                return NotFound();
            }

            return dTCInventory;
        }

        // PUT: api/DTCInventories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDTCInventory(string id, DTCInventory dTCInventory)
        {
            if (id != dTCInventory.DTCTechnicalId)
            {
                return BadRequest();
            }

            _context.Entry(dTCInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DTCInventoryExists(id))
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

        // POST: api/DTCInventories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DTCInventory>> PostDTCInventory(DTCInventory dTCInventory)
        {
            _context.DTCInventories.Add(dTCInventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DTCInventoryExists(dTCInventory.DTCTechnicalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDTCInventory", new { id = dTCInventory.DTCTechnicalId }, dTCInventory);
        }

        // DELETE: api/DTCInventories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTCInventory>> DeleteDTCInventory(string id)
        {
            var dTCInventory = await _context.DTCInventories.FindAsync(id);
            if (dTCInventory == null)
            {
                return NotFound();
            }

            _context.DTCInventories.Remove(dTCInventory);
            await _context.SaveChangesAsync();

            return dTCInventory;
        }

        private bool DTCInventoryExists(string id)
        {
            return _context.DTCInventories.Any(e => e.DTCTechnicalId == id);
        }
    }
}
