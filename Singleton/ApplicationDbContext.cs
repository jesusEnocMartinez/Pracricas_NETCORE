namespace WebApplication1.Singleton
{
    using global::WebApplication1.Model;
    using Microsoft.EntityFrameworkCore;

    namespace WebApplication1.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Producto> Productos { get; set; }
        }
    }

}
