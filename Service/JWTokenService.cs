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
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

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
