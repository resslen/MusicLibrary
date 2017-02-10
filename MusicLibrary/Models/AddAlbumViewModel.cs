using System.Collections.Generic;

namespace MusicLibrary.Models
{
    public class AddAlbumViewModel
    {
        public int AuthorId { get; set; }
        public IEnumerable<ArtistListViewModel> Artists { get; set; }
    }
}