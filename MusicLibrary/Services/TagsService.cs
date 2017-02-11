using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MusicLibrary.DAL;
using MusicLibrary.Exceptions;

namespace MusicLibrary.Services
{
    public class TagsService : ITagsService
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
            string[] tagsRequest;
            if (tags != null)
            {
                tagsRequest = tags.ToLower().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                tagsRequest = new string[0];
            }
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

        public void CleanTags()
        {
            var unusedTags = _context.Tags
                .Where(x => x.Albums.Count == 0);
            _context.Tags.RemoveRange(unusedTags);
            _context.SaveChanges();
        }

        public Tag GetTag(int id)
        {
            var tag = _context.Tags
                .Include(x => x.Albums.Select(y => y.Author))
                .SingleOrDefault(x => x.Id == id);
            if (tag == null)
            {
                throw new NotFoundException();
            }
            return tag;
        }
    }
}