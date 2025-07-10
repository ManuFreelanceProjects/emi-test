using IdentityManager.Domain.Entities;
using IdentityManager.Domain.Repositories;

namespace IdentityManager.Domain.Services;

public class InMemoryUserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User GetUserByUsername(string username)
    {
        return _users.FirstOrDefault(u => u.UserName.Equals(username));
    }
}
