using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.DataTransferObject;
using Restful_API.Model;


namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleContext _context;

        public RoleController(RoleContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetRole()
        {
            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Role>>> CreateRoles([FromBody] RoleDto dto
            )
        {
            if (dto == null)
            {
                return BadRequest("IsrDto is required");
            }

            var role = new Role
            {
                id = dto.id,
                role_id = dto.role_id,
                role_description = dto.role_description
            };

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Role>>> UpdateIsrs([FromBody] UpdateRoleDto dto)
        {
            if (dto == null)
            {
                return BadRequest("UpdateIsrDto is required");

            }

            var dbRESTFUL = await _context.Roles.FindAsync(dto.id);

            if (dbRESTFUL == null)
            {
                return NotFound("Isr not found");
            }

            dbRESTFUL.id = dto.id;
            dbRESTFUL.role_id = dto.role_id;
            dbRESTFUL.role_description = dto.role_description;


            await _context.SaveChangesAsync();
            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Isr>>> DeleteIsrs(int id)
        {

            var dbRESTFUL = await _context.Roles.FindAsync(id);
            if (dbRESTFUL == null)
                return BadRequest("Role not found");

            _context.Roles.Remove(dbRESTFUL);
            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }
   }

}
