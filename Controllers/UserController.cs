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

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserList()
        {
            return Ok(await _context.Users.ToListAsync());

        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate Password
            if (!IsValidPassword(createUserDto.user_password))
                return BadRequest("Password must be at least 8 characters long, contain at least one uppercase letter, one special character, and one numeric digit.");

            // Validate AbfiId
            if (string.IsNullOrWhiteSpace(createUserDto.abfi_id))
                return BadRequest("AbfiId cannot be empty.");

            if (await _context.Users.AnyAsync(u => u.abfi_id == createUserDto.abfi_id))
                return BadRequest("ID has already been used.");

            // Validate Contact Number
            if (string.IsNullOrWhiteSpace(createUserDto.contact_num) ||
                createUserDto.contact_num.Length != 11 ||
                !createUserDto.contact_num.All(char.IsDigit))
                return BadRequest("Contact Number must be exactly 11 digits.");

            // Validate Username
            if (string.IsNullOrWhiteSpace(createUserDto.username) || createUserDto.username.Length < 8)
                return BadRequest("Username must be at least 8 characters long.");

            // Validate Email Address
            if (string.IsNullOrWhiteSpace(createUserDto.email_add) ||
                !createUserDto.email_add.EndsWith("@abfiph.com") ||
                !new EmailAddressAttribute().IsValid(createUserDto.email_add))
                return BadRequest("Email address must be a valid address with domain '@abfiph.com'.");

            if (await _context.Users.AnyAsync(u => u.email_add == createUserDto.email_add))
                return BadRequest("Email address must be unique.");

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
                            return BadRequest("A user with the same ID or email address already exists.");
                        case 547: // Foreign key violation
                            return BadRequest("A related record does not exist.");
                        default:
                            return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected database error occurred.");
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
    }
}

