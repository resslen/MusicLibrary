using System.Collections.Generic;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public interface IAlbumsService
    {
        IEnumerable<AlbumListViewModel> GetAlbums(string sort = null, string search = null);
        AlbumViewModel AlbumById(int id);
        int AddAlbum(NewAlbumViewModel model);
        void DeleteById(int id);
        void UpdateAlbum(int id, NewAlbumViewModel model);
        AddAlbumViewModel GetAddViewModel();
        EditAlbumViewModel GetEditViewModel(int id);
    }
}
