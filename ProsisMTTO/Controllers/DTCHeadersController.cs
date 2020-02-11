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
    public class DTCHeadersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DTCHeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DTCHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTCHeader>>> GetDTCHeaders()
        {
            return await _context.DTCHeaders.ToListAsync();
        }

        // GET: api/DTCHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTCHeader>> GetDTCHeader(string id)
        {
            var dTCHeader = await _context.DTCHeaders.FindAsync(id);

            if (dTCHeader == null)
            {
                return NotFound();
            }

            return dTCHeader;
        }

        // PUT: api/DTCHeaders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDTCHeader(string id, DTCHeader dTCHeader)
        {
            if (id != dTCHeader.DTCHeaderId)
            {
                return BadRequest();
            }

            _context.Entry(dTCHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DTCHeaderExists(id))
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

        // POST: api/DTCHeaders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DTCHeader>> PostDTCHeader(DTCHeader dTCHeader)
        {
            _context.DTCHeaders.Add(dTCHeader);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DTCHeaderExists(dTCHeader.DTCHeaderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDTCHeader", new { id = dTCHeader.DTCHeaderId }, dTCHeader);
        }

        // DELETE: api/DTCHeaders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTCHeader>> DeleteDTCHeader(string id)
        {
            var dTCHeader = await _context.DTCHeaders.FindAsync(id);
            if (dTCHeader == null)
            {
                return NotFound();
            }

            _context.DTCHeaders.Remove(dTCHeader);
            await _context.SaveChangesAsync();

            return dTCHeader;
        }

        private bool DTCHeaderExists(string id)
        {
            return _context.DTCHeaders.Any(e => e.DTCHeaderId == id);
        }
    }
}
