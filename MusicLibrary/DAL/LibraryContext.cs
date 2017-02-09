using System.Data.Entity;

namespace MusicLibrary.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("MusicLibraryConnString")
        {}

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}