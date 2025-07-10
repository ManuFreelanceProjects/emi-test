using IdentityManager.Application.Interfaces;
using IdentityManager.Domain.Entities;
using IdentityManager.Domain.Repositories;

namespace IdentityManager.Application.UseCases.Users;

public class UserUseCase : IUserUseCase
{
    private readonly IUserRepository _userRepository;
    public UserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Authenticates a user by checking the provided username and password against the stored user data.
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <returns>The authenticated user.</returns>
    /// <exception cref="Exception"></exception>
    public User AuthenticateUser(string userName, string password)
    {
        var user = _userRepository.GetUserByUsername(userName);
        if (user == null || user.Password != password)
        {
            throw new Exception("Invalid username or password.");
        }
        return user;
    }

    /// <summary>
    /// Registers a new user by checking if the username already exists and then adding the user to the repository.
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="password"></param>
    /// <param name="role"></param>
    /// <exception cref="Exception">When the user already exist.</exception>
    public void RegisterUser(string userName, string password, string role)
    {
        if (_userRepository.GetUserByUsername(userName) != null)
        {
            throw new Exception("User already exists.");
        }

        var user = new User
        {
            Id = new Random().Next(1, 1000),
            UserName = userName,
            Password = password,
            Role = role

        };
        _userRepository.AddUser(user);
    }
}
