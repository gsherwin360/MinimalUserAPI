using Microsoft.EntityFrameworkCore;
using MinimalUserAPI.Entities;

namespace MinimalUserAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users => Set<User>();
} // End of class