using Microsoft.EntityFrameworkCore;
using MinimalUserAPI.Data;
using MinimalUserAPI.Entities;

namespace MinimalUserAPI.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateUser(User user)
    {
        if(user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        await _context.AddAsync(user);
    }

    public void DeleteUser(User user)
    {
        if(user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        
        _context.Users.Remove(user);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
} // End of class