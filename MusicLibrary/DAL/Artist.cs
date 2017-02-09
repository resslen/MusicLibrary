using System.Collections.Generic;

namespace MusicLibrary.DAL
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IList<Album> Albums{ get; set; }
        public string LastFmUrl { get; set; }
        public int AlbumCount { get; set; }
    }
}