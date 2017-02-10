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

        public AlbumsService(LibraryContext context)
        {
            _context = context;
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
    }
}