using Microsoft.EntityFrameworkCore;
using Restful_API.Data;
using Restful_API.Model;

public class UserService
{
    private readonly UserContext _context;

    public UserService(UserContext context)
    {
        _context = context;
    }

    public User GetUserByUsername(string username)
    {
        return _context.Users
            .Include(u => u.Role)  // Load the Role entity
            .FirstOrDefault(u => u.username == username);
    }
}
