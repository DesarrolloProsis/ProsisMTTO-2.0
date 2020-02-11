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
    public class DTCTechnicalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DTCTechnicalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DTCTechnicals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTCTechnical>>> GetDTCTechnical()
        {
            return await _context.DTCTechnical.ToListAsync();
        }

        // GET: api/DTCTechnicals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTCTechnical>> GetDTCTechnical(string id)
        {
            var dTCTechnical = await _context.DTCTechnical.FindAsync(id);

            if (dTCTechnical == null)
            {
                return NotFound();
            }

            return dTCTechnical;
        }

        // PUT: api/DTCTechnicals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDTCTechnical(string id, DTCTechnical dTCTechnical)
        {
            if (id != dTCTechnical.ReferenceNum)
            {
                return BadRequest();
            }

            _context.Entry(dTCTechnical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DTCTechnicalExists(id))
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

        // POST: api/DTCTechnicals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DTCTechnical>> PostDTCTechnical(DTCTechnical dTCTechnical)
        {
            _context.DTCTechnical.Add(dTCTechnical);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DTCTechnicalExists(dTCTechnical.ReferenceNum))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDTCTechnical", new { id = dTCTechnical.ReferenceNum }, dTCTechnical);
        }

        // DELETE: api/DTCTechnicals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTCTechnical>> DeleteDTCTechnical(string id)
        {
            var dTCTechnical = await _context.DTCTechnical.FindAsync(id);
            if (dTCTechnical == null)
            {
                return NotFound();
            }

            _context.DTCTechnical.Remove(dTCTechnical);
            await _context.SaveChangesAsync();

            return dTCTechnical;
        }

        private bool DTCTechnicalExists(string id)
        {
            return _context.DTCTechnical.Any(e => e.ReferenceNum == id);
        }
    }
}
