using Microsoft.EntityFrameworkCore;
using PublisherDomain;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PublisherData
{
    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PubDatabase;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var authorList = new Author[]
            {
                new Author{ Id = 1, FirstName = "Ronja", LastName = "Levi"},
                new Author{ Id = 2, FirstName = "Rita", LastName = "Olsson"},
                new Author{ Id = 3, FirstName = "Sofia", LastName = "Smith"},
                new Author{ Id = 4, FirstName = "Ursula", LastName = "Levin"},
                new Author{ Id = 5, FirstName = "Harry", LastName = "Howey"},
                new Author{ Id = 6, FirstName = "Isabelle", LastName = "Allie"}
            };

            modelBuilder.Entity<Author>().HasData(authorList);

        }
    }
    
    
}
