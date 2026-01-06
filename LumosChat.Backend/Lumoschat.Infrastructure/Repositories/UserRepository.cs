using LumosChat.Application.Contracts.Repositories;
using LumosChat.Domain.Entities;
using LumosChat.Infrastructure.Contexts;
using LumosChat.Infrastructure.Contexts.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LumosChat.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LumosChatDbContext _context;

        public UserRepository(LumosChatDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> AddUserAsync(User user) => await _context.AddandSaveAsync(user);

        public async Task<bool> ExistByUsernameAsync(string username) =>
            await _context.Users.AnyAsync(u => u.Username == username);

        public async Task<User> GetByUsernameAsync(string username) =>
            (await _context.Users.FirstOrDefaultAsync(u => u.Username == username))
            ?? new User { Username = "Unknown", PasswordHash = "" };
    }
}
