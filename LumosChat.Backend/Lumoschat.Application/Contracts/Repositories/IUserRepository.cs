using LumosChat.Domain.Entities;

namespace LumosChat.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> GetByUsernameAsync(string username);
        Task<bool> ExistByUsernameAsync(string username);
    }
}
