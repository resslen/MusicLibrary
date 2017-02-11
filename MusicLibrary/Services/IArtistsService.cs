using System.Collections.Generic;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public interface IArtistsService
    {
        IEnumerable<ArtistListViewModel> AllArtists(string sort = null);
        ArtistViewModel ArtistById(int id);
        void DeleteById(int id);
        int AddArtist(NewArtistViewModel model);
        void UpdateArtist(int id, NewArtistViewModel model);
    }
}
