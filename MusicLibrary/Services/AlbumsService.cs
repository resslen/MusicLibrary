using MusicLibrary.DAL;

namespace MusicLibrary.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly LibraryContext _context;

        public AlbumsService(LibraryContext context)
        {
            _context = context;
        }
    }
}