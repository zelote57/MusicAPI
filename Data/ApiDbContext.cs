using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;

namespace MusicAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) 
            : base(options)
        {            
        }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Populate Songs

            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "Abc",
                    Language = "Spanish",
                    Duration = "3 mnts"
                },
                new Song
                {
                    Id = 2,
                    Title = "Si nos dejan",
                    Language = "Spanish",
                    Duration = "2.58 mnts"
                },
                new Song
                {
                    Id = 3,
                    Title = "Only you",
                    Language = "English",
                    Duration = "2.0 mnts"
                });

            #endregion
        }
    }
}
