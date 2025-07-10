using IdentityManager.Domain.Entities;

namespace IdentityManager.Application.Interfaces;

public interface IUserUseCase
{
    void RegisterUser(string userName, string password, string role);
    User AuthenticateUser(string userName, string password);
}
