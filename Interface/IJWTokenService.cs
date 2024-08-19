using Restful_API.Model;

namespace Restful_API.Interface
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(User user);
    }
}