using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.DataTransferObject;
using Restful_API.Model;

namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly AreaContext _context;

        public AreaController(AreaContext context)
        {
            _context = context;
        }
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetUserCount()
        {
            var count = await _context.Areas.CountAsync();
            return Ok(count);
        }

        [HttpGet]
        public async Task<ActionResult<List<Area>>> GetArea()
        {
            return Ok(await _context.Areas.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Area>>> CreateArea([FromBody] Area dto
            )
        {
            if (dto == null)
            {
                return BadRequest("AreaDto is required");
            }

            var area = new Area
            {
                id = dto.id,
                area = dto.area,
                description = dto.description
            };

            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return Ok(await _context.Areas.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Area>>> UpdateArea([FromBody] UpdateAreaDto dto)
        {
            if (dto == null)
            {
                return BadRequest("UpdateAreaDto is required");

            }

            var dbRESTFUL = await _context.Areas.FindAsync(dto.id);

            if (dbRESTFUL == null)
            {
                return NotFound("Isr not found");
            }

            dbRESTFUL.id = dto.id;
            dbRESTFUL.area = dto.area;
            dbRESTFUL.description = dto.description;


            await _context.SaveChangesAsync();
            return Ok(await _context.Areas.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Area>>> DeleteArea(int id)
        {

            var dbRESTFUL = await _context.Areas.FindAsync(id);
            if (dbRESTFUL == null)
                return BadRequest("Area not found");

            _context.Areas.Remove(dbRESTFUL);
            await _context.SaveChangesAsync();

            return Ok(await _context.Areas.ToListAsync());
        }
    }

}
