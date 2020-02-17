using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("AllowAPIRequest")]
    public class LanesCatalogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LanesCatalogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LanesCatalogs
        [HttpGet]
        public async Task<ActionResult<List<object>>> GetLanesCatalogs()
        {
            var query = await (from a in _context.LanesCatalogs
                               join s in _context.TypeCarrils
                               on a.LaneType equals s.TypeCarrilId
                               select new
                               {

                                   CapufeLaneNum = a.CapufeLaneNum,
                                   Lane = a.Lane,
                                   IdGare = a.IdGare,
                                   TypeCarril = s.Name,
                                   SquaresCatalogId = a.SquaresCatalogId

                               }).ToListAsync<object>();

            return Ok(query); 
        }

        [HttpGet("{id}/{id2}")]
        public async Task<ActionResult<List<LanesCatalog>>> GetLanesCatalog(string id, string id2)
        {
            var lanesCatalog = await _context.LanesCatalogs.Where(x => x.CapufeLaneNum == id && x.IdGare == id2).ToListAsync();
            //var lanesCatalog = await _context.LanesCatalogs.FindAsync(id);

            if (lanesCatalog == null)
            {
                return NotFound();
            }

            return lanesCatalog;
        }


        // GET: api/LanesCatalogs/5
        [HttpGet("params/{param1}/{param2?}")]
        public async Task<ActionResult<List<object>>> GetLanesCatalog(string param1, int? param2)
        {
            try
            {
                if (param2 == null)
                {
                    //var lanesCatalog = await _context.LanesCatalogs.Where(x => x.SquaresCatalogId == param1).ToListAsync();

                    var lanesCatalog = await (from a in _context.LanesCatalogs
                                       join s in _context.TypeCarrils
                                       on a.LaneType equals s.TypeCarrilId
                                       where (a.SquaresCatalogId == param1)
                                       select new
                                       {

                                           CapufeLaneNum = a.CapufeLaneNum,
                                           Lane = a.Lane,
                                           IdGare = a.IdGare,
                                           TypeCarril = s.Name,
                                           SquaresCatalogId = a.SquaresCatalogId

                                       }).ToListAsync<object>();

                    if (lanesCatalog == null)
                    {
                        return NotFound();
                    }

                    return lanesCatalog;
                }
                else
                {
                    //var lanesCatalog = await _context.LanesCatalogs.Where(x => x.SquaresCatalogId == param1 && x.LaneType == param2).ToListAsync();

                    var lanesCatalog = await (from a in _context.LanesCatalogs
                                       join s in _context.TypeCarrils
                                       on a.LaneType equals s.TypeCarrilId
                                       where(a.SquaresCatalogId == param1 && a.LaneType == param2)
                                       select new
                                       {

                                           CapufeLaneNum = a.CapufeLaneNum,
                                           Lane = a.Lane,
                                           IdGare = a.IdGare,
                                           TypeCarril = s.Name,
                                           SquaresCatalogId = a.SquaresCatalogId

                                       }).ToListAsync<object>();

                    if (lanesCatalog == null)
                    {
                        return NotFound();
                    }

                    return Ok(lanesCatalog);
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}/{id2}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<IActionResult> PutLanesCatalog(string id, string id2, LanesCatalog lanesCatalog)
        {

            if (id != lanesCatalog.CapufeLaneNum && id2 != lanesCatalog.IdGare)
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
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<LanesCatalog>> PostLanesCatalog([FromBody] LanesCatalog lanesCatalog)
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
                    return Content("Existe");
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLanesCatalog", new { id = lanesCatalog.CapufeLaneNum, id2 = lanesCatalog.IdGare }, lanesCatalog);
        }

        // DELETE: api/LanesCatalogs/5
        [HttpDelete("{id}/{id2}")]
        [EnableCors("AllowAPIRequest")]
        public async Task<ActionResult<LanesCatalog>> DeleteLanesCatalog(string id, string id2)
        {
            var lanesCatalog = await _context.LanesCatalogs.Where(x => x.CapufeLaneNum == id && x.IdGare == id2).FirstAsync();

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
