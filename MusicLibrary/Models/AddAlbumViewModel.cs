using System.Collections.Generic;
using System.Linq;

namespace MusicLibrary.Models
{
    public class AddAlbumViewModel
    {
        public AddAlbumViewModel(IEnumerable<ArtistListViewModel> artists)
        {
            Artists = artists;
        }

        public int AuthorId => Artists.First().Id;
        public IEnumerable<ArtistListViewModel> Artists { get; set; }
    }
}