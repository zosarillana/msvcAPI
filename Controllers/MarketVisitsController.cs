using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.DataTransferObject;

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
        public async Task<ActionResult<List<MarketVisit>>> CreateMarketVisits([FromBody] MarketVisitDto dto)
        {
            if (dto == null)
            {
                return BadRequest("MarketVisitDto is required.");
            }

            // Create a new MarketVisit entity
            var marketVisit = new MarketVisit
            {
                user_id = dto.user_id,
                visit_date = dto.visit_date,
                visit_area = dto.visit_area,
                visit_accountName = dto.visit_accountName,
                visit_distributor = dto.visit_distributor,
                visit_salesPersonnel = dto.visit_salesPersonnel,
                visit_accountType = dto.visit_accountType,
                isr_id = dto.isr_id,
                visit_isrNeed = dto.visit_isrNeed,
                visit_payolaMerchandiser = dto.visit_payolaMerchandiser,
                visit_averageOffTakePd = dto.visit_averageOffTakePd,
            pod_id = dto.pod_id,
                visit_competitorsCheck = dto.visit_competitorsCheck,
                visit_pap = dto.visit_pap
            };

            _context.MarketVisits.Add(marketVisit);
            await _context.SaveChangesAsync();

            return Ok(await _context.MarketVisits.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<MarketVisit>>> UpdateMarketVisits([FromBody] UpdateMarketVisitDto dto)
        {
            if (dto == null)
            {
                return BadRequest("MarketVisitUpdateDto is required.");
            }

            var dbRESTFUL = await _context.MarketVisits.FindAsync(dto.id);

            if (dbRESTFUL == null)
            {
                return NotFound("Visit not found");
            }

            dbRESTFUL.user_id = dto.user_id;
            dbRESTFUL.visit_date = dto.visit_date;
            dbRESTFUL.visit_area = dto.visit_area;
            dbRESTFUL.visit_accountName = dto.visit_accountName;
            dbRESTFUL.visit_distributor = dto.visit_distributor;
            dbRESTFUL.visit_salesPersonnel = dto.visit_salesPersonnel;
            dbRESTFUL.visit_accountType = dto.visit_accountType;
            dbRESTFUL.isr_id = dto.isr_id;
            dbRESTFUL.visit_isrNeed = dto.visit_isrNeed;
            dbRESTFUL.visit_payolaMerchandiser = dto.visit_payolaMerchandiser;
            dbRESTFUL.visit_payolaSupervisor = dto.visit_payolaSupervisor;
            dbRESTFUL.visit_averageOffTakePd = dto.visit_averageOffTakePd;
            dbRESTFUL.pod_id = dto.pod_id;            
            dbRESTFUL.visit_competitorsCheck = dto.visit_competitorsCheck;
            dbRESTFUL.visit_pap = dto.visit_pap;

            await _context.SaveChangesAsync();

            return Ok(await _context.MarketVisits.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<MarketVisit>>> DeleteMarketVisits(int id)
        {

            var dbRESTFUL = await _context.MarketVisits.FindAsync(id);
            if (dbRESTFUL == null)
                return BadRequest("Visit not found");

            _context.MarketVisits.Remove(dbRESTFUL);
            await _context.SaveChangesAsync();

            return Ok(await _context.MarketVisits.ToListAsync());
        }
    }
}
