using LumosChat.Application.DTOs;
using LumosChat.Domain.Entities;

namespace LumosChat.Application.Abstractions
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterUserDTO dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
