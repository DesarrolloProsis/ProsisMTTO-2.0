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
    public class InventoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
        {
            return await _context.Inventories.ToListAsync();
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        [HttpGet("params/{param1?}/{param2?}")]
        public async Task<ActionResult<List<object>>> GetInventory(string? param1, string? param2)
        {
            try
            {
                var inventory = new List<object>();
                if (param1 == null && param2 == null)
                {
                    return NotFound();
                }

                else if (param2 == null)
                {
                    //sparePartsCatalog = await _context.SparePartsCatalogs.Where(x => x.PieceYear == param1);
                    inventory = await _context.Inventories
                       .Where(x => x.PieceYear == param1)
                       .Select(x => new
                       {
                           NumPart = x.NumPart,
                           TypeService = x.TypeService,
                           Name = x.Name,
                           Brand = x.Brand,
                           Price = x.Price,
                           Unit = x.Unit,
                           PiceYear = x.PieceYear,
                           SparePartImage = x.SparePartImage,
                           Description = x.Description
                       })
                      .ToListAsync<object>();

                    if (inventory == null)
                    {
                        return NotFound();
                    }

                    return inventory;

                }

                else if (param1 == "null")
                {
                    inventory = await _context.Inventories
                        .Where(x => x.Brand == param2)
                        .Select(x => new
                        {
                            NumPart = x.NumPart,
                            TypeService = x.TypeService,
                            Name = x.Name,
                            Brand = x.Brand,
                            Price = x.Price,
                            Unit = x.Unit,
                            PiceYear = x.PieceYear,
                            SparePartImage = x.SparePartImage,
                            Description = x.Description
                        })
                        .ToListAsync<object>();

                    if (inventory == null)
                    {
                        return NotFound();
                    }

                    return inventory;
                }

                else
                {
                    inventory = await _context.Inventories
                        .Where(x => x.PieceYear == param1 && x.Brand == param2)
                        .Select(x => new
                        {
                            NumPart = x.NumPart,
                            TypeService = x.TypeService,
                            Name = x.Name,
                            Brand = x.Brand,
                            Price = x.Price,
                            Unit = x.Unit,
                            PiceYear = x.PieceYear,
                            SparePartImage = x.SparePartImage,
                            Description = x.Description
                        })
                        .ToListAsync<object>();

                    if (inventory == null)
                    {
                        return NotFound();
                    }

                    return inventory;
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
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
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
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
