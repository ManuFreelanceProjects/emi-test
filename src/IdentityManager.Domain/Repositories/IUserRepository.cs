using IdentityManager.Domain.Entities;

namespace IdentityManager.Domain.Repositories;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUserByUsername(string username);
}
