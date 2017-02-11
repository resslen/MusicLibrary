using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Models
{
    public class NewArtistViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Max length of name is 60 characters")]
        public string Name { get; set; }
        [StringLength(65536, ErrorMessage = "Max length of description if 65536 characters")]
        public string Description { get; set; }
        [StringLength(255, ErrorMessage = "Max length of url if 255 characters")]
        public string LastFmUrl { get; set; }
    }
}