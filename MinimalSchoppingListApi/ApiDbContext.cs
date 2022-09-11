using Microsoft.EntityFrameworkCore;

namespace MinimalSchoppingListApi
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Grocery> Groseries => Set<Grocery>();

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

    }
}
