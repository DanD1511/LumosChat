using LumosChat.Domain.Common;

namespace LumosChat.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public string? AvatarUrl { get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
