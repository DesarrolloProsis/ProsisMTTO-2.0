using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsisMTTO.Context;
using ProsisMTTO.Entities;

namespace ProsisMTTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Inventories
        [HttpGet]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
        {
            return await _context.Inventories.ToListAsync();
        }

        // GET: api/Inventories/5
        [HttpGet("year/{year}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventoryYear(string year)
        {
            var inventory = await _context.Inventories.Where(x => x.PieceYear == year).ToListAsync();

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        [HttpGet("marca/{brand}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventoryBrand(string brand)
        {
            var inventory = await _context.Inventories.Where(x => x.Brand == brand).ToListAsync();

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        [HttpGet("{year}/{brand}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventory(string year, string brand)
        {
            var inventory = await _context.Inventories.Where(x => x.PieceYear == year && x.Brand == brand).ToListAsync();

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }


        // PUT: api/Inventories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<IActionResult> PutInventory(int id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            _context.Inventories.Add(inventory);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                var l = ex;
            }

            return CreatedAtAction("GetInventory", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<Inventory>> DeleteInventory(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();

            return inventory;
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.Id == id);
        }
    }
}
