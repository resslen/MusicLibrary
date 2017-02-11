using System.Collections.Generic;

namespace MusicLibrary.Models
{
    public class EditAlbumViewModel
    {
        public AlbumViewModel Album { get; set; }
        public IEnumerable<ArtistListViewModel> Artists { get; set; }
        public int AuthorId => Album.AuthorId;
        public int Id => Album.Id;
    }
}