using System.Collections.Generic;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public interface IAlbumsService
    {
        IEnumerable<AlbumListViewModel> AllAbums();
        AlbumViewModel AlbumById(int id);
    }
}
