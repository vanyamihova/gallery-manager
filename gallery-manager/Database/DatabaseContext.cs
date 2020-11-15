using gallery_manager.Database.Entity;
using gallery_manager.Models;
using Microsoft.EntityFrameworkCore;

namespace gallery_manager.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<GalleryEntity> Gallery { get; set; }

        public DbSet<ImageEntity> Image { get; set; }

        public DatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=gallery_db;user=gallery_user;password=gallery_password");
        }
    }
}
