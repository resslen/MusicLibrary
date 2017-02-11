using System.Collections.Generic;
using MusicLibrary.Models;

namespace MusicLibrary.Services
{
    public interface IArtistsService
    {
        IEnumerable<ArtistListViewModel> GetArtists(string sort = null, string search = null);
        ArtistViewModel ArtistById(int id);
        void DeleteById(int id);
        int AddArtist(NewArtistViewModel model);
        void UpdateArtist(int id, NewArtistViewModel model);
    }
}
