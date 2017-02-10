using System.Collections.Generic;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public interface IArtistsService
    {
        IEnumerable<ArtistListViewModel> AllArtists();
        ArtistViewModel ArtistById(int id);
        void DeleteById(int id);
        int AddArtist(NewArtistViewModel model);
    }
}
