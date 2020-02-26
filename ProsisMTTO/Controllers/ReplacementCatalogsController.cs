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
    public class ReplacementCatalogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReplacementCatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ReplacementCatalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReplacementCatalog>>> GetReplacementCatalogs()
        {
            return await _context.ReplacementCatalogs.ToListAsync();
        }

        // GET: api/ReplacementCatalogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReplacementCatalog>> GetReplacementCatalog(int id)
        {
            var replacementCatalog = await _context.ReplacementCatalogs.FindAsync(id);

            if (replacementCatalog == null)
            {
                return NotFound();
            }

            return replacementCatalog;
        }

        // PUT: api/ReplacementCatalogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReplacementCatalog(int id, ReplacementCatalog replacementCatalog)
        {
            if (id != replacementCatalog.ReplacementCatalogId)
            {
                return BadRequest();
            }

            _context.Entry(replacementCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReplacementCatalogExists(id))
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

        // POST: api/ReplacementCatalogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ReplacementCatalog>> PostReplacementCatalog(ReplacementCatalog replacementCatalog)
        {
            _context.ReplacementCatalogs.Add(replacementCatalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReplacementCatalog", new { id = replacementCatalog.ReplacementCatalogId }, replacementCatalog);
        }

        // DELETE: api/ReplacementCatalogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReplacementCatalog>> DeleteReplacementCatalog(int id)
        {
            var replacementCatalog = await _context.ReplacementCatalogs.FindAsync(id);
            if (replacementCatalog == null)
            {
                return NotFound();
            }

            _context.ReplacementCatalogs.Remove(replacementCatalog);
            await _context.SaveChangesAsync();

            return replacementCatalog;
        }

        private bool ReplacementCatalogExists(int id)
        {
            return _context.ReplacementCatalogs.Any(e => e.ReplacementCatalogId == id);
        }
    }
}
