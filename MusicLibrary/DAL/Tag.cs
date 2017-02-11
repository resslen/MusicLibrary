using System.Collections.Generic;

namespace MusicLibrary.DAL
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}