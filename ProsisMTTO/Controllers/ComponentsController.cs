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
    public class ComponentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComponentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Components
        [HttpGet]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
            return await _context.Components.ToListAsync();
        }

        // GET: api/Components/5
        [HttpGet("{year}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponent(string year)
        {
            var component = await _context.Components.Where(x => x.Year == year).ToListAsync();

            if (component == null)
            {
                return NotFound();
            }

            return component;
        }

        // PUT: api/Components/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<IActionResult> PutComponent(int id, Component component)
        {
            if (id != component.ComponentId)
            {
                return BadRequest();
            }

            _context.Entry(component).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentExists(id))
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

        // POST: api/Components
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<Component>> PostComponent(Component component)
        {
            _context.Components.Add(component);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponent", new { id = component.ComponentId }, component);
        }

        // DELETE: api/Components/5
        [HttpDelete("{id}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<Component>> DeleteComponent(int id)
        {
            var component = await _context.Components.FindAsync(id);
            if (component == null)
            {
                return NotFound();
            }

            _context.Components.Remove(component);
            await _context.SaveChangesAsync();

            return component;
        }

        private bool ComponentExists(int id)
        {
            return _context.Components.Any(e => e.ComponentId == id);
        }
    }
}
