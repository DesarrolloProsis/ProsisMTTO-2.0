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
    [EnableCors("AllowAPIRequest")]
    public class SparePartsCatalogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SparePartsCatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SparePartsCatalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SparePartsCatalog>>> GetSparePartsCatalogs()
        {
            return await _context.SparePartsCatalogs.ToListAsync();
        }

        // GET: api/SparePartsCatalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SparePartsCatalog>> GetSparePartsCatalog(string id)
        {
            var sparePartsCatalog = await _context.SparePartsCatalogs.FindAsync(id);

            if (sparePartsCatalog == null)
            {
                return NotFound();
            }

            return sparePartsCatalog;
        }

        [HttpGet("params/{param1?}/{param2?}")]
        public async Task<ActionResult<List<object>>> GetSparePartsCatalog(string? param1, string? param2)
        {
            try
            {
                var sparePartsCatalog = new List<object>();
                if (param1 == "null" && param2 == "null")
                {
                    return NotFound();
                }

                else if (param2 == "null")
                {
                    sparePartsCatalog = await _context.SparePartsCatalogs
                       .Where(x => x.PieceYear == param1)
                       .Select(x => new
                       {
                           Id = x.NumPart,
                           NombreRefaccion = x.Name,
                           Marca = x.Brand,
                           Precio = x.Price,
                           Unidad = x.Unit
                       })
                      .ToListAsync<object>();

                    if (sparePartsCatalog == null)
                    {
                        return NotFound();
                    }

                    return sparePartsCatalog;

                }

                else if (param1 == "null")
                {
                    sparePartsCatalog = await _context.SparePartsCatalogs
                        .Where(x => x.Brand == param2)
                        .Select(x => new
                        {
                            Id = x.NumPart,
                            NombreRefaccion = x.Name,
                            Marca = x.Brand,
                            Precio = x.Price,
                            Unidad = x.Unit
                        })
                        .ToListAsync<object>();

                    if (sparePartsCatalog == null)
                    {
                        return NotFound();
                    }

                    return sparePartsCatalog;
                }

                else
                {
                    sparePartsCatalog = await _context.SparePartsCatalogs
                        .Where(x => x.PieceYear == param1 && x.Brand == param2)
                        .Select(x => new
                        {
                            Id = x.NumPart,
                            NombreRefaccion = x.Name,
                            Marca = x.Brand,
                            Precio = x.Price,
                            Unidad = x.Unit
                        })
                        .ToListAsync<object>();

                    if (sparePartsCatalog == null)
                    {
                        return NotFound();
                    }

                    return sparePartsCatalog;
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/SparePartsCatalogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSparePartsCatalog(string id, SparePartsCatalog sparePartsCatalog)
        {
            if (id != sparePartsCatalog.NumPart)
            {
                return BadRequest();
            }

            _context.Entry(sparePartsCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SparePartsCatalogExists(id))
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

        // POST: api/SparePartsCatalogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SparePartsCatalog>> PostSparePartsCatalog(SparePartsCatalog sparePartsCatalog)
        {
            _context.SparePartsCatalogs.Add(sparePartsCatalog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SparePartsCatalogExists(sparePartsCatalog.NumPart))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSparePartsCatalog", new { id = sparePartsCatalog.NumPart }, sparePartsCatalog);
        }

        // DELETE: api/SparePartsCatalogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SparePartsCatalog>> DeleteSparePartsCatalog(string id)
        {
            var sparePartsCatalog = await _context.SparePartsCatalogs.FindAsync(id);
            if (sparePartsCatalog == null)
            {
                return NotFound();
            }

            _context.SparePartsCatalogs.Remove(sparePartsCatalog);
            await _context.SaveChangesAsync();

            return sparePartsCatalog;
        }

        private bool SparePartsCatalogExists(string id)
        {
            return _context.SparePartsCatalogs.Any(e => e.NumPart == id);
        }
    }
}
