using LumosChat.Domain.Common;

namespace LumosChat.Domain.Entities
{
    public class Message : BaseEntity
    {
        public required string Content { get; set; }

        public Guid UserID { get; set; }
        public User? User { get; set; }
    }
}
