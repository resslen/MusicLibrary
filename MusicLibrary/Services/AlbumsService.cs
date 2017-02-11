using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using MusicLibrary.DAL;
using MusicLibrary.Exceptions;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly LibraryContext _context;
        private readonly IArtistsService _artistsService;
        private readonly ISortService _sortService;

        public AlbumsService(LibraryContext context, IArtistsService artistsService, ISortService sortService)
        {
            _context = context;
            _artistsService = artistsService;
            _sortService = sortService;
        }

        private Album Find(int id)
        {
            var album = _context.Albums
                .Include(x => x.Author)
                .SingleOrDefault(x => x.Id == id);
            if (album == null)
            {
                throw new NotFoundException();
            }
            return album;
        }

        public IEnumerable<AlbumListViewModel> AllAbums(string sort = null)
        {
            var albumsDal = _context.Albums
                .Include(x => x.Author);
            var albums = _sortService.Sort(albumsDal, sort)
                .ToList();
            return Mapper.Map<IEnumerable<AlbumListViewModel>>(albums);
        }

        public AlbumViewModel AlbumById(int id)
        {
            var album = Find(id);
            return Mapper.Map<AlbumViewModel>(album);
        }

        public int AddAlbum(NewAlbumViewModel model)
        {
            var artist = _context.Artists.Find(model.AuthorId);
            if (artist == null)
            {
                throw new NotFoundException();
            }
            artist.AlbumCount += 1;
            var album = Mapper.Map<Album>(model);
            _context.Albums.Add(album);
            _context.SaveChanges();
            return album.Id;
        }

        public void DeleteById(int id)
        {
            var album = Find(id);
            var artist = _context.Artists.Find(album.AuthorId);
            _context.Albums.Remove(album);
            artist.AlbumCount -= 1;
            _context.SaveChanges();
        }

        public void UpdateAlbum(int id, NewAlbumViewModel model)
        {
            var album = Find(id);
            Mapper.Map(model, album);
            _context.SaveChanges();
        }

        public AddAlbumViewModel GetAddViewModel()
        {
            var artists = _artistsService.GetArtists();
            return new AddAlbumViewModel(artists);
        }

        public EditAlbumViewModel GetEditViewModel(int id)
        {
            return new EditAlbumViewModel
            {
                Album = AlbumById(id),
                Artists = _artistsService.GetArtists()
            };
        }
    }
}