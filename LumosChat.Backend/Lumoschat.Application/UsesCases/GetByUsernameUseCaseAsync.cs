using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LumosChat.Application.Contracts.Repositories;
using LumosChat.Domain.Entities;

namespace LumosChat.Application.UsesCases
{
    public class GetByUsernameUseCaseAsync
    {
        private readonly IUserRepository _userRepository;

        public GetByUsernameUseCaseAsync(IUserRepository userRepository)
        {
            _userRepository =
                userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null)
                return new User { Username = "", PasswordHash = "" };

            return user;
        }
    }
}
