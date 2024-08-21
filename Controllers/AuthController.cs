using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.DataTransferObject;
using Restful_API.Interface;
using Restful_API.Model;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserContext _userContext;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(UserContext userContext, IJwtTokenService jwtTokenService)
    {
        _userContext = userContext;
        _jwtTokenService = jwtTokenService;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var errors = new Dictionary<string, List<string>>();

        if (string.IsNullOrEmpty(loginDto.username))
        {
            if (!errors.ContainsKey("username"))
            {
                errors["username"] = new List<string>();
            }
            errors["username"].Add("Username is required");
        }

        if (string.IsNullOrEmpty(loginDto.user_password))
        {
            if (!errors.ContainsKey("user_password"))
            {
                errors["user_password"] = new List<string>();
            }
            errors["user_password"].Add("Password is required");
        }

        if (errors.Count > 0)
        {
            return BadRequest(new { errors });
        }

        var user = await _userContext.Users
            .SingleOrDefaultAsync(u => u.username == loginDto.username);

        if (user == null || !user.VerifyPassword(loginDto.user_password))
        {
            return Unauthorized(new { errors = new { general = new List<string> { "Invalid credentials" } } });
        }

        var token = _jwtTokenService.GenerateJwtToken(user);

        var userDto = new
        {
            user.username,
            user.user_password,
            user.fname,
            user.mname,
            user.lname,
            user.role,
            user.contact_num,
            user.email_add,
        };

        return Ok(new
        {
            Token = token,
            User = userDto
        });
    }

}
