using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MusicLibrary.DAL;
using MusicLibrary.Exceptions;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public class ArtistsService : IArtistsService
    {
        private LibraryContext _context;

        public ArtistsService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<ArtistListViewModel> AllArtists()
        {
            var artists = _context.Artists.ToList();
            return Mapper.Map<List<ArtistListViewModel>>(artists);
        }

        public ArtistViewModel ArtistById(int id)
        {
            var artist = _context.Artists.Find(id);
            if (artist == null)
            {
                throw new NotFountException();
            }
            return Mapper.Map<ArtistViewModel>(artist);
        }
    }
}