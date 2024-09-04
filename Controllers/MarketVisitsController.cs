using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restful_API.Data;
using Restful_API.DataTransferObject;
using Restful_API.Model;
using System.Linq;

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
        private readonly string uploadDir = @"C:\Users\zcsarillana\source\repos\uploads";

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(MarketVisit), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MarketVisit>> CreateMarketVisit([FromForm] MarketVisitDto request)
        {
            if (string.IsNullOrEmpty(request.visit_date) || string.IsNullOrEmpty(request.visit_accountName))
            {
                return BadRequest("Required form fields are missing.");
            }

            try
            {
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                string uniqueFileName = null;
                if (request.file != null && request.file.Length > 0)
                {
                    // Validate file size and type
                    if (request.file.Length > 10 * 1024 * 1024) // 10 MB limit
                    {
                        return BadRequest("File size exceeds the limit.");
                    }

                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
                    var fileExtension = Path.GetExtension(request.file.FileName).ToLowerInvariant();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        return BadRequest("Invalid file type.");
                    }

                    // Generate a unique file name
                    var uniqueFileNameWithoutExtension = Guid.NewGuid().ToString();
                    uniqueFileName = $"{uniqueFileNameWithoutExtension}{fileExtension}";

                    var filePath = Path.Combine(uploadDir, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await request.file.CopyToAsync(stream);
                    }
                }

                var pod = new MarketVisit
                {
                    user_id = request.user_id,
                    visit_date = request.visit_date,
                    area_id = request.area_id,
                    visit_accountName = request.visit_accountName,
                    visit_accountType = request.visit_accountType,
                    visit_distributor = request.visit_distributor,
                    visit_salesPersonnel = request.visit_salesPersonnel,
                    isr_id = request.isr_id,
                    isr_reqOthers = request.isr_reqOthers,
                    visit_payolaSupervisor = request.visit_payolaSupervisor,
                    visit_payolaMerchandiser = request.visit_payolaMerchandiser,
                    visit_averageOffTakePd = request.visit_averageOffTakePd,
                    pod_id = request.pod_id,
                    visit_competitorsCheck = request.visit_competitorsCheck,
                    isr_needs_ImgPath = uniqueFileName,
                    isr_req_ImgPath = uniqueFileName // Adjust if needed
                };

                _context.MarketVisits.Add(pod);
                await _context.SaveChangesAsync();

                return Ok(pod);
            }
            catch (Exception ex)
            {
                // Use a logging framework for better logging
                // _logger.LogError(ex, "An error occurred while creating a pod.");
                return StatusCode(500, "Internal server error.");
            }
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
            dbRESTFUL.area_id = dto.area_id;
            dbRESTFUL.visit_accountName = dto.visit_accountName;
            dbRESTFUL.visit_distributor = dto.visit_distributor;
            dbRESTFUL.visit_salesPersonnel = dto.visit_salesPersonnel;
            dbRESTFUL.visit_accountType = dto.visit_accountType;
            dbRESTFUL.isr_id = dto.isr_id;
            dbRESTFUL.isr_reqOthers = dto.isr_reqOthers;
            dbRESTFUL.isr_req_ImgPath = dto.isr_req_ImgPath;
            dbRESTFUL.isr_needsOthers = dto.isr_needsOthers;
            dbRESTFUL.isr_needs_ImgPath = dto.isr_needs_ImgPath;
            
            dbRESTFUL.visit_payolaMerchandiser = dto.visit_payolaMerchandiser;
            dbRESTFUL.visit_payolaSupervisor = dto.visit_payolaSupervisor;
            dbRESTFUL.visit_averageOffTakePd = dto.visit_averageOffTakePd;
            dbRESTFUL.pod_id = dto.pod_id;      
            dbRESTFUL.pod_canned_other = dto.pod_canned_other;
            dbRESTFUL.pod_mpp_other = dto.pod_mpp_other;
            dbRESTFUL.pap_others = dto.pap_others;
            dbRESTFUL.visit_competitorsCheck = dto.visit_competitorsCheck;
            dbRESTFUL.pap_id = dto.pap_id;

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
