﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProsisMTTO.Context;
using ProsisMTTO.Entities;

namespace ProsisMTTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanesCatalogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LanesCatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LanesCatalogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanesCatalog>>> GetLanesCatalogs()
        {
            return await _context.LanesCatalogs.ToListAsync();
        }

        //[HttpGet("{param1}/{param2}")]
        //[Route("api/params/")]
        //public HttpResponseMessage Get

        // GET: api/LanesCatalogs/5
        [HttpGet("{param1}/{param2}")]
        public async Task<ActionResult<List<LanesCatalog>>> GetLanesCatalog(string param1, int param2)
        {
            var lanesCatalog = await _context.LanesCatalogs.Where(x => x.SquaresCatalogId == param1 && x.LaneType == param2).ToListAsync();

            if (lanesCatalog == null)
            {
                return NotFound();
            }

            return lanesCatalog;
        }

        // PUT: api/LanesCatalogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanesCatalog(string id, LanesCatalog lanesCatalog)
        {
            if (id != lanesCatalog.CapufeLaneNum)
            {
                return BadRequest();
            }

            _context.Entry(lanesCatalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanesCatalogExists(id))
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

        // POST: api/LanesCatalogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LanesCatalog>> PostLanesCatalog(LanesCatalog lanesCatalog)
        {
            _context.LanesCatalogs.Add(lanesCatalog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LanesCatalogExists(lanesCatalog.CapufeLaneNum))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLanesCatalog", new { id = lanesCatalog.CapufeLaneNum }, lanesCatalog);
        }

        // DELETE: api/LanesCatalogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LanesCatalog>> DeleteLanesCatalog(string id)
        {
            var lanesCatalog = await _context.LanesCatalogs.FindAsync(id);
            if (lanesCatalog == null)
            {
                return NotFound();
            }

            _context.LanesCatalogs.Remove(lanesCatalog);
            await _context.SaveChangesAsync();

            return lanesCatalog;
        }

        private bool LanesCatalogExists(string id)
        {
            return _context.LanesCatalogs.Any(e => e.CapufeLaneNum == id);
        }
    }
}
