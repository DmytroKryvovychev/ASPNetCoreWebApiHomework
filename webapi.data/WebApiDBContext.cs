using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using webapi.data.Entities;

namespace webapi.data
{
    public class WebApiDbContext: DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set;}

        public WebApiDbContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
            DbInitializer.Initialize(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Books)
                .WithOne(b => b.Genre)
                .HasForeignKey(k => k.GenreId);
        }
    }
}
