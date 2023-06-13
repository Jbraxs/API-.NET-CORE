using Microsoft.EntityFrameworkCore;

namespace CrudRazor.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }

        public DbSet<Curso> Curso { get; set; }
    }
}
