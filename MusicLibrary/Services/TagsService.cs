using System;
using System.Collections.Generic;
using System.Linq;
using MusicLibrary.DAL;

namespace MusicLibrary.Services
{
    public class TagsService
    {
        private readonly LibraryContext _context;
        private readonly ISortService _sortService;

        public TagsService(LibraryContext context, ISortService sortService)
        {
            _context = context;
            _sortService = sortService;
        }

        public IEnumerable<Tag> GetTags(string sort = null, string search = null)
        {
            IQueryable<Tag> tags = _context.Tags;
            if (search != null)
            {
                search = search.ToLower();
                tags = tags
                    .Where(x => x.Name.ToLower().Contains(search));
            }
            tags = _sortService.Sort(tags, sort);
            return tags.ToList();
        }

        public void UpdateAlbumWithTags(Album album, string tags)
        {
            var tagsRequest = tags.ToLower().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var tagsInDb = new List<Tag>();
            var newTags = new List<Tag>();

            // take tags in database to tagsInDb 
            // and tags not in database to newTags
            foreach (var tag in tagsRequest)
            {
                var tagInDb = _context.Tags.SingleOrDefault(x => x.Name == tag);
                if (tagInDb != null)
                {
                    tagsInDb.Add(tagInDb);
                }
                else
                {
                    newTags.Add(new Tag()
                    {
                        Name = tag
                    });
                }
            }

            // add new tags to database
            _context.Tags.AddRange(newTags);

            // set new tags for album
            var albumTags = album.Tags;
            albumTags.Clear();
            foreach (var tag in newTags)
            {
                albumTags.Add(tag);
            }
            foreach (var tag in tagsInDb)
            {
                albumTags.Add(tag);
            }
        }
    }
}