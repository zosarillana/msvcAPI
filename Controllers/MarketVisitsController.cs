using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;

namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketVisitsController : ControllerBase
    {
        private readonly MarketVisitContext _context;
        public MarketVisitsController(MarketVisitContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MarketVisit>>> GetMarketVisits()
        {
            return Ok(await _context.MarketVisits.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<MarketVisit>>> CreateMarketVisits(MarketVisit marketVisit)
        {
            _context.MarketVisits.Add(marketVisit);
            await _context.SaveChangesAsync();

            return Ok(await _context.MarketVisits.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<MarketVisit>>> UpdateMarketVisits(MarketVisit marketVisit)
        {
            // Find the existing record
            var dbRESTFUL = await _context.MarketVisits.FindAsync(marketVisit.id);

            // Check if the record exists
            if (dbRESTFUL == null)
                return BadRequest("Visit not found");

            // Update the fields with the new values
            dbRESTFUL.area = marketVisit.area;
            dbRESTFUL.visitor = marketVisit.visitor;
            dbRESTFUL.visitdate = marketVisit.visitdate;

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the updated list of MarketVisits
            return Ok(await _context.MarketVisits.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<MarketVisit>>> DeleteMarketVisits(int id) {

            var dbRESTFUL = await _context.MarketVisits.FindAsync(id);
            if (dbRESTFUL == null)
                return BadRequest("Visit not found");

            _context.MarketVisits.Remove(dbRESTFUL);
            await _context.SaveChangesAsync();

            return Ok(await _context.MarketVisits.ToListAsync());
        }
    }
}
