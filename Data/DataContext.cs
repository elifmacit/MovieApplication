using Microsoft.EntityFrameworkCore;
using MovieApplication.Enums;
using MovieApplication.Models;

namespace MovieApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CategoryMovie> CategoryMovies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BaseEntity'nin tablo olarak oluşturulmamasını sağla
            modelBuilder.Ignore<BaseEntity>();

            // CategoryMovie: Many-to-Many Ara Tablo Ayarları
            modelBuilder.Entity<CategoryMovie>()
                .HasKey(cm => new { cm.CategoryId, cm.MovieId }); // Composite Key Tanımı

            modelBuilder.Entity<CategoryMovie>()
                .HasOne(cm => cm.Category)
                .WithMany(c => c.CategoryMovies)
                .HasForeignKey(cm => cm.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict

            modelBuilder.Entity<CategoryMovie>()
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.CategoryMovies)
                .HasForeignKey(cm => cm.MovieId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict

            // Category Ayarları
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasMaxLength(250);

            // Movie Ayarları
            modelBuilder.Entity<Movie>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Author)
                .HasMaxLength(100);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Url)
                .HasMaxLength(200);

            modelBuilder.Entity<Movie>()
                .Property(m => m.Picture)
                .HasMaxLength(200);
        }

    }
}
