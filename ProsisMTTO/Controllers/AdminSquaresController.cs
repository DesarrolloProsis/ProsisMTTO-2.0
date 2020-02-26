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
    public class AdminSquaresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminSquaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AdminSquares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminSquare>>> GetAdminSquares()
        {
            return await _context.AdminSquares.ToListAsync();
        }

        // GET: api/AdminSquares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminSquare>> GetAdminSquare(string id)
        {
            var adminSquare = await _context.AdminSquares.FindAsync(id);

            if (adminSquare == null)
            {
                return NotFound();
            }

            return adminSquare;
        }

        // PUT: api/AdminSquares/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminSquare(string id, AdminSquare adminSquare)
        {
            if (id != adminSquare.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(adminSquare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminSquareExists(id))
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

        // POST: api/AdminSquares
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AdminSquare>> PostAdminSquare(AdminSquare adminSquare)
        {
            _context.AdminSquares.Add(adminSquare);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdminSquareExists(adminSquare.AdminId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdminSquare", new { id = adminSquare.AdminId }, adminSquare);
        }

        // DELETE: api/AdminSquares/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdminSquare>> DeleteAdminSquare(string id)
        {
            var adminSquare = await _context.AdminSquares.FindAsync(id);
            if (adminSquare == null)
            {
                return NotFound();
            }

            _context.AdminSquares.Remove(adminSquare);
            await _context.SaveChangesAsync();

            return adminSquare;
        }

        private bool AdminSquareExists(string id)
        {
            return _context.AdminSquares.Any(e => e.AdminId == id);
        }
    }
}
