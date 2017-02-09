using System.Data.Entity;

namespace MusicLibrary.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("MusicLibraryConnString")
        {
        }
    }
}