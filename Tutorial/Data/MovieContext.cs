using Microsoft.EntityFrameworkCore;
using Tutorial.ViewModel;

namespace Tutorial.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MovieViewModel> Movie { get; set; }
    }
}