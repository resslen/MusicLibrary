using System.Collections.Generic;
using MusicLibrary.DAL;

namespace MusicLibrary.Models
{
    public class AlbumViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public string Tracklist { get; set; }
        public string LastFmUrl { get; set; }
        public int Year { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}