using System.Collections.Generic;

namespace MusicLibrary.DAL
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Artist Author { get; set; }
        public string Tracklist { get; set; }
        public string LastFmUrl { get; set; }
        public int Year { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}