using Microsoft.EntityFrameworkCore;

namespace LumosChat.Infrastructure.Contexts.Extensions
{
    public static class DbContextExtensions
    {
        public static async Task<T> AddandSaveAsync<T>(this DbContext context, T entity)
            where T : class
        {
            if (context == null || entity == null)
                throw new ArgumentNullException(nameof(context));

            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
