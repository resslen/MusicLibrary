using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Models
{
    public class NewAlbumViewModel
    {
        [Required(ErrorMessage = "The title is required")]
        [StringLength(100, ErrorMessage = "Max length of title is 100 characters")]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [StringLength(65535, ErrorMessage = "Max length of tracklist if 65535 characters")]
        public string Tracklist { get; set; }
        [StringLength(255, ErrorMessage = "Max length of url if 255 characters")]
        public string LastFmUrl { get; set; }
        [Required(ErrorMessage = "The year is required")]
        public int Year { get; set; }
        [StringLength(1000, ErrorMessage = "Max length of tags if 1000 characters")]
        public string Tags { get; set; }
    }
}