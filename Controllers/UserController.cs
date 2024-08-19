using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.DataTransferObject;
using Restful_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Restful_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
        }
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetUserCount()
        {
            var count = await _context.Users.CountAsync();
            return Ok(count);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserList()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(CreateUserDto createUserDto)
        {
            var errors = new Dictionary<string, List<string>>();

            // Validate Password
            if (!IsValidPassword(createUserDto.user_password))
                errors["user_password"] = new List<string> { "Password must be at least 8 characters long, contain at least one uppercase letter, one special character, and one numeric digit." };

            // Validate AbfiId
            if (string.IsNullOrWhiteSpace(createUserDto.abfi_id))
                errors["abfi_id"] = new List<string> { "AbfiId cannot be empty." };

            if (await _context.Users.AnyAsync(u => u.abfi_id == createUserDto.abfi_id))
                errors["abfi_id"] = new List<string> { "ID has already been used." };

            // Validate Contact Number
            if (string.IsNullOrWhiteSpace(createUserDto.contact_num) ||
                createUserDto.contact_num.Length != 11 ||
                !createUserDto.contact_num.All(char.IsDigit))
                errors["contact_num"] = new List<string> { "Contact Number must be exactly 11 digits." };

            // Validate Username
            if (string.IsNullOrWhiteSpace(createUserDto.username) || createUserDto.username.Length < 8)
                errors["username"] = new List<string> { "Username must be at least 8 characters long." };

            // Validate Email Address
            if (string.IsNullOrWhiteSpace(createUserDto.email_add) ||
                !createUserDto.email_add.EndsWith("@abfiph.com") ||
                !new EmailAddressAttribute().IsValid(createUserDto.email_add))
                errors["email_add"] = new List<string> { "Email address must be a valid address with domain '@abfiph.com'." };

            if (await _context.Users.AnyAsync(u => u.email_add == createUserDto.email_add))
                errors["email_add"] = new List<string> { "Email address must be unique." };

            if (errors.Count > 0)
                return BadRequest(new { errors });

            // Create new user
            var user = new User
            {
                abfi_id = createUserDto.abfi_id,
                fname = createUserDto.fname,
                mname = createUserDto.mname,
                lname = createUserDto.lname,
                role = createUserDto.role,
                contact_num = createUserDto.contact_num,
                email_add = createUserDto.email_add,
                username = createUserDto.username,
                date_created = DateTime.UtcNow,
                date_updated = DateTime.UtcNow
            };

            user.SetPassword(createUserDto.user_password); // Hash the password

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log exception details for debugging
                Console.WriteLine($"Error: {ex.Message}");

                if (ex.InnerException is SqlException sqlEx)
                {
                    switch (sqlEx.Number)
                    {
                        case 2627: // Unique constraint violation
                            errors["general"] = new List<string> { "A user with the same ID or email address already exists." };
                            return BadRequest(new { errors });
                        case 547: // Foreign key violation
                            errors["general"] = new List<string> { "A related record does not exist." };
                            return BadRequest(new { errors });
                        default:
                            errors["general"] = new List<string> { "An unexpected database error occurred." };
                            return StatusCode(StatusCodes.Status500InternalServerError, new { errors });
                    }
                }

                // Rethrow if not handled above
                throw;
            }

            return CreatedAtAction(nameof(GetUserList), new { id = user.id }, user);
        }

        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            // Password must be at least 8 characters long
            if (password.Length < 8)
                return false;

            // Password must contain at least one uppercase letter
            if (!password.Any(char.IsUpper))
                return false;

            // Password must contain at least one special character
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                return false;

            // Password must contain at least one numeric digit
            if (!password.Any(char.IsDigit))
                return false;

            return true;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { errors = ModelState });
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            // Update user properties
            user.abfi_id = updateUserDto.abfi_id;
            user.fname = updateUserDto.fname;
            user.mname = updateUserDto.mname;
            user.lname = updateUserDto.lname;
            user.role = updateUserDto.role;
            user.contact_num = updateUserDto.contact_num;
            user.email_add = updateUserDto.email_add;
            user.username = updateUserDto.username;
            user.date_updated = DateTime.UtcNow;

            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var errors = new Dictionary<string, List<string>>();

                if (ex.InnerException is SqlException sqlEx)
                {
                    switch (sqlEx.Number)
                    {
                        case 2627: // Unique constraint violation
                            errors["general"] = new List<string> { "A user with the same ID or email address already exists." };
                            break;
                        case 547: // Foreign key violation
                            errors["general"] = new List<string> { "A related record does not exist." };
                            break;
                        default:
                            errors["general"] = new List<string> { "An unexpected database error occurred." };
                            break;
                    }
                    return BadRequest(new { errors });
                }

                throw;
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {

            var dbRESTFUL = await _context.Users.FindAsync(id);
            if (dbRESTFUL == null)
                return BadRequest("Visit not found");

            _context.Users.Remove(dbRESTFUL);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
    }

}
