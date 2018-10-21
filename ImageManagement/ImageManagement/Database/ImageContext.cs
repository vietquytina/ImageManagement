using MySql.Data.Entity;
using System.Data.Entity;

namespace ImageManagement.Database
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ImageContext : DbContext
    {
        public DbSet<ImageFile> ImageFiles { get; set; }

        public DbSet<Pixel> Pixels { get; set; }

        public ImageContext() : base("MyContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pixel>().HasKey(m => new { m.FileId, m.PixelX, m.PixelY });
        }
    }
}
