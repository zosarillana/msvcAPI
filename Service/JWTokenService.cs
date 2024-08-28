using Microsoft.IdentityModel.Tokens;
using Restful_API.Interface;
using Restful_API.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtTokenService : IJwtTokenService
{
    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _secretKey;

    public JwtTokenService(string issuer, string audience, string secretKey)
    {
        _issuer = issuer;
        _audience = audience;
        _secretKey = secretKey;
    }

    public string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>();

        if (user != null)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.username ?? string.Empty));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            // Use role_id directly from User
            claims.Add(new Claim("role_id", user.role_id.ToString()));

            // Use null-coalescing operators to handle nullable properties
            claims.Add(new Claim("fname", user.fname ?? string.Empty));
            claims.Add(new Claim("mname", user.mname ?? string.Empty));
            claims.Add(new Claim("lname", user.lname ?? string.Empty));
            claims.Add(new Claim("contact_num", user.contact_num ?? string.Empty));
            claims.Add(new Claim("abfi_id", user.abfi_id ?? string.Empty));
        }
        else
        {
            // Handle the case where user is null
            throw new InvalidOperationException("User is null and cannot create claims.");
        }

        var claimsArray = claims.ToArray();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

