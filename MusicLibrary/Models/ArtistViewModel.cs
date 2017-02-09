using System.Collections.Generic;
using MusicLibrary.DAL;

namespace MusicLibrary.Models
{
    public class ArtistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Album> Albums { get; set; }
        public string LastFmUrl { get; set; }
        public int AlbumCount { get; set; }
    }
}