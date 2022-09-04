using Common.Models;
using Microsoft.EntityFrameworkCore;


namespace Lesson3.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {}

        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
    }
}
