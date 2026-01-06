using LumosChat.Domain.Entities;

namespace LumosChat.Application.Contracts.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
