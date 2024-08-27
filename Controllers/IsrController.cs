using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.DataTransferObject;
using Restful_API.Model;

namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsrController : ControllerBase
    {
        private readonly IsrContext _context;
        public IsrController(IsrContext context) { 
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Isr>>> GetIsrs()
        {
            return Ok(await _context.Isrs.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Isr>>> CreateIsrs([FromBody] IsrDto dto
            )
        {
            if (dto == null) {
                return BadRequest("IsrDto is required");
            }

            var isr = new Isr
            {
                id = dto.id,
                isr_name = dto.isr_name,
                isr_others = dto.isr_others,
                isr_type = dto.isr_type,
                description = dto.description,
                image_path = dto.image_path
            };

            _context.Isrs.Add(isr);
            await _context.SaveChangesAsync();

            return Ok(await _context.Isrs.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Isr>>> UpdateIsrs([FromBody] UpdateIsrDto dto)
        {
            if (dto == null)
            {
                return BadRequest("UpdateIsrDto is required");

            }

           var dbRESTFUL = await _context.Isrs.FindAsync(dto.id);

            if (dbRESTFUL == null) 
            { 
            return NotFound("Isr not found");
            }
            
            dbRESTFUL.id = dto.id;          
            dbRESTFUL.isr_name = dto.isr_name;
            dbRESTFUL.isr_type = dto.isr_type;
            dbRESTFUL.isr_others = dto.isr_others;
            dbRESTFUL.description = dto.description;
            dbRESTFUL.image_path = dto.image_path;

            await _context.SaveChangesAsync();
            return Ok(await _context.Isrs.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Isr>>> DeleteIsrs(int id) {

            var dbRESTFUL = await _context.Isrs.FindAsync(id);
            if (dbRESTFUL == null)
                return BadRequest("Visit not found");

            _context.Isrs.Remove(dbRESTFUL);
            await _context.SaveChangesAsync();

            return Ok(await _context.Isrs.ToListAsync());
        }
    }  
        
       
}
