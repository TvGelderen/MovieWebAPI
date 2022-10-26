using Microsoft.EntityFrameworkCore;
using MovieWebAPI.Models;

namespace MovieWebAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Movie> Movie_db { get; set; }
    }
}
