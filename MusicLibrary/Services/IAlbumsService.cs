using System.Collections.Generic;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public interface IAlbumsService
    {
        IEnumerable<AlbumListViewModel> AllAbums(string sort = null);
        AlbumViewModel AlbumById(int id);
        int AddAlbum(NewAlbumViewModel model);
        void DeleteById(int id);
        void UpdateAlbum(int id, NewAlbumViewModel model);
        AddAlbumViewModel GetAddViewModel();
        EditAlbumViewModel GetEditViewModel(int id);
    }
}
