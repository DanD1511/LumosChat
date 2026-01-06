using LumosChat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LumosChat.Infrastructure.Contexts
{
    public class LumosChatDbContext : DbContext
    {
        public LumosChatDbContext(DbContextOptions<LumosChatDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
