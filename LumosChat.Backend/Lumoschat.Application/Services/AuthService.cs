using LumosChat.Application.Abstractions;
using LumosChat.Application.Contracts.Authentication;
using LumosChat.Application.DTOs;
using LumosChat.Application.UsesCases;
using LumosChat.Domain.Entities;

namespace LumosChat.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly RegisterUseCaseAsync _registerAsync;
        private readonly GetByUsernameUseCaseAsync _getByUsernameUseCaseAsync;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(
            RegisterUseCaseAsync registerAsync,
            GetByUsernameUseCaseAsync getByUsernameUseCase,
            IJwtTokenGenerator jwtTokenGenerator
        )
        {
            _registerAsync =
                registerAsync ?? throw new ArgumentNullException(nameof(registerAsync));

            _getByUsernameUseCaseAsync =
                getByUsernameUseCase
                ?? throw new ArgumentNullException(nameof(getByUsernameUseCase));

            _jwtTokenGenerator =
                jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _getByUsernameUseCaseAsync.GetUserAsync(dto.Username);

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                throw new Exception("Invalid Credentials");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return token;
        }

        public async Task<User> RegisterAsync(RegisterUserDTO dto) =>
            await _registerAsync.RegisterUserAsync(dto);
    }
}
