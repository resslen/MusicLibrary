using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using MusicLibrary.DAL;
using MusicLibrary.Exceptions;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public class ArtistsService : IArtistsService
    {
        private readonly LibraryContext _context;

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
            var artist = _context.Artists
                .Include(x => x.Albums)
                .SingleOrDefault(x => x.Id == id);
                
            if (artist == null)
            {
                throw new NotFoundException();
            }
            return Mapper.Map<ArtistViewModel>(artist);
        }

        public void DeleteById(int id)
        {
            var artist = _context.Artists.Find(id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();
        }
    }
}