using LumosChat.Application.Contracts.Repositories;
using LumosChat.Application.DTOs;
using LumosChat.Domain.Entities;

namespace LumosChat.Application.UsesCases
{
    public class RegisterUseCaseAsync
    {
        private readonly IUserRepository _userRepository;

        public RegisterUseCaseAsync(IUserRepository userRepository)
        {
            _userRepository =
                userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<User> RegisterUserAsync(RegisterUserDTO dto)
        {
            if (await _userRepository.ExistByUsernameAsync(dto.Username))
            {
                throw new Exception("El usuario ya existe.");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var newUser = new User
            {
                Username = dto.Username,
                PasswordHash = passwordHash,
                AvatarUrl = $"https://robohash.org/{dto.Username}",
            };

            return await _userRepository.AddUserAsync(newUser);
        }
    }
}
