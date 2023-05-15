using MinimalUserAPI.Entities;

namespace MinimalUserAPI.Services;

public interface IUserService
{
    Task SaveChanges();
    Task<User?> GetUserById(int id);
    Task<IEnumerable<User>> GetAllUsers();
    Task CreateUser(User user);
    void DeleteUser(User user);
} // End of interface