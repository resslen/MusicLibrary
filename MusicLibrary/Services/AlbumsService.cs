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

        public AlbumsService(LibraryContext context, IArtistsService artistsService)
        {
            _context = context;
            _artistsService = artistsService;
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

        public IEnumerable<AlbumListViewModel> AllAbums()
        {
            var albums = _context.Albums
                .Include(x => x.Author)
                .OrderBy(x => x.Author.Name)
                .ThenBy(x => x.Title)
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
            _context.Albums.Remove(album);
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
            var artists = _artistsService.AllArtists();
            return new AddAlbumViewModel(artists);
        }

        public EditAlbumViewModel GetEditViewModel(int id)
        {
            return new EditAlbumViewModel
            {
                Album = AlbumById(id),
                Artists = _artistsService.AllArtists()
            };
        }
    }
}