using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.DataTransferObject;
using Restful_API.Model;

namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodController : ControllerBase
    {
        private readonly PodContext _context;
        public PodController(PodContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Pod>>> GetPods()
        {
            return Ok(await _context.Pods.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Pod>>> CreatePod([FromBody] CreatePodDto dto
            )
        {
            if (dto == null)
            {
                return BadRequest("PodDto is required");
            }

            var pod = new Pod
            {
                id = dto.id,
                pod_name = dto.pod_name,
                pod_others = dto.pod_others,
                pod_type = dto.pod_type,
                description = dto.description,
                image_path = dto.image_path
            };

            _context.Pods.Add(pod);
            await _context.SaveChangesAsync();

            return Ok(await _context.Pods.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Pod>>> UpdateIsrs([FromBody] UpdatePodDto dto)
        {
            if (dto == null)
            {
                return BadRequest("UpdatePodDto is required");

            }

            var dbRESTFUL = await _context.Pods.FindAsync(dto.id);

            if (dbRESTFUL == null)
            {
                return NotFound("Isr not found");
            }

            dbRESTFUL.id = dto.id;
            dbRESTFUL.pod_name = dto.pod_name;
            dbRESTFUL.pod_type = dto.pod_type;
            dbRESTFUL.pod_others = dto.pod_others;
            dbRESTFUL.description = dto.description;
            dbRESTFUL.image_path = dto.image_path;

            await _context.SaveChangesAsync();
            return Ok(await _context.Pods.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Pod>>> DeletePod(int id)
        {

            var dbRESTFUL = await _context.Pods.FindAsync(id);
            if (dbRESTFUL == null)
                return BadRequest("Pod not found");

            _context.Pods.Remove(dbRESTFUL);
            await _context.SaveChangesAsync();

            return Ok(await _context.Pods.ToListAsync());
        }


    }
}
