using System.Collections.Generic;

namespace MusicLibrary.DAL
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public ICollection<Album> Albums { get; set; }


        public Tag()
        {
        }

        public Tag(string name)
        {
            Name = name;
            Count = 1;
        }
    }
}