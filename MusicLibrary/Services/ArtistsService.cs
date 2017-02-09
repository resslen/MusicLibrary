using MusicLibrary.DAL;

namespace MusicLibrary.Services
{
    public class ArtistsService : IArtistsService
    {
        private LibraryContext _context;

        public ArtistsService(LibraryContext context)
        {
            _context = context;
        }
    }
}