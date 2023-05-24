using Microsoft.EntityFrameworkCore;
using SpotifyClone.Core.DataBase.Entities;

namespace MusicDataBaseEntityFramework.Entities
{
    public class MyMusicDbContext : DbContext
    {
        public MyMusicDbContext(DbContextOptions<MyMusicDbContext> options) : base(options)
        {
            
        }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>(x =>
            {
                x.Property(p => p.Title).IsRequired();
                x.Property(p => p.Time).IsRequired();
                x.HasOne(a => a.Performer).WithMany(s => s.Songs).HasForeignKey(k => k.PerformerId).
                IsRequired();

                x.HasOne(p => p.Album).WithMany(a => a.Songs).HasForeignKey(k => k.AlbumId);
                x.HasMany(p => p.Playlists).WithMany(s => s.Songs);
            });

            modelBuilder.Entity<Album>(x =>
            {
                x.Property(p => p.Name).IsRequired();
                x.Property(p => p.ReleaseDate).IsRequired();

                x.HasOne(p => p.Performer).WithMany(a => a.Albums).HasForeignKey(k => k.PerformerId);
            });

            modelBuilder.Entity<Performer>(x =>
            {
                x.Property(p => p.Name).IsRequired();
                x.Property(p => p.PerformerType).IsRequired();
            });

            modelBuilder.Entity<Playlist>(x =>
            {
                x.HasOne(u => u.User).WithMany(p => p.Playlists).HasForeignKey(u => u.UserId);
                x.Property(p => p.Title).HasMaxLength(70);
            });

            modelBuilder.Entity<User>(x =>
            {
                //x.HasData(new User { Id = Guid.NewGuid(), FirstName = "Tomek", LastName = "Nowak", LoginEmail = "email", Password = "password" });
            });
        }
    }
}
