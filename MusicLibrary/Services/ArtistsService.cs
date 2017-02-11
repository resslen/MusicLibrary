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
        private readonly ISortService _sortService;

        public ArtistsService(LibraryContext context, ISortService sortService)
        {
            _context = context;
            _sortService = sortService;
        }

        private Artist Find(int id)
        {
            var artist = _context.Artists.Find(id);
            if (artist == null)
            {
                throw new NotFoundException();
            }
            return artist;
        }

        public IEnumerable<ArtistListViewModel> AllArtists(string sort = null)
        {
            var artistsDal = _context.Artists;
            var artists = _sortService.Sort(artistsDal, sort)
                .ToList();
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
            var artist = Find(id);
            _context.Artists.Remove(artist);
            _context.SaveChanges();
        }

        public int AddArtist(NewArtistViewModel model)
        {
            var artist = Mapper.Map<Artist>(model);
            _context.Artists.Add(artist);
            _context.SaveChanges();
            return artist.Id;
        }

        public void UpdateArtist(int id, NewArtistViewModel model)
        {
            var artist = Find(id);
            Mapper.Map(model, artist);
            _context.SaveChanges();
        }
    }
}