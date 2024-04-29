using Microsoft.EntityFrameworkCore;

namespace JuliaPhotoServer.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoSet> PhotoSets { get; set; }
        public DbSet<PhotoSetType> PhotoSetTypes { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}

