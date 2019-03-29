using Microsoft.EntityFrameworkCore;
 
namespace BrightIdeas.Models
{
    public class BrightIdeasContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BrightIdeasContext(DbContextOptions<BrightIdeasContext> options) : base(options) { }
        public DbSet<User> user { get; set; }
        public DbSet<Idea> idea { get; set; }
        public DbSet<Likenit> likenit { get; set; }
    }
}