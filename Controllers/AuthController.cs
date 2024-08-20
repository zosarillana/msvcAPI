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
        if (loginDto == null || string.IsNullOrEmpty(loginDto.username) || string.IsNullOrEmpty(loginDto.user_password))
        {
            return BadRequest(new { message = "Username and password are required" });
        }

        var user = await _userContext.Users
            .SingleOrDefaultAsync(u => u.username == loginDto.username);

        if (user == null || !user.VerifyPassword(loginDto.user_password))
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        var token = _jwtTokenService.GenerateJwtToken(user);

        // Include user details in the response
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
