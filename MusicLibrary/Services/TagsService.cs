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
            var tagsRequest = SplitRequest(tags);
            var notPresentInAlbum = NotPresentTags(tagsRequest, album);
            var notInRequest = NotInRequestTags(tagsRequest, album);

            RemoveTags(notInRequest, album);
            AddTags(notPresentInAlbum, album);
        }

        private void AddTags(IEnumerable<string> tags, Album album)
        {
            foreach (var name in tags)
            {
                var tag = _context.Tags.SingleOrDefault(x => x.Name == name);
                if (tag != null)
                {
                    tag.Count += 1;
                }
                else
                {
                    tag = new Tag(name);
                }
                album.Tags.Add(tag);
            }
        }

        private void RemoveTags(IEnumerable<Tag> tags, Album album)
        {
            foreach (var tag in tags)
            {
                album.Tags.Remove(tag);
                tag.Count -= 1;
                if (tag.Count == 0)
                {
                    _context.Tags.Remove(tag);
                }
            }
        }

        private IEnumerable<string> NotPresentTags(IEnumerable<string> tagsRequest, Album album)
        {
            return tagsRequest
                .Where(x => album.Tags.All(y => y.Name != x))
                .ToList();
        }

        private IEnumerable<Tag> NotInRequestTags(IEnumerable<string> tagsRequest, Album album)
        {
            return album.Tags
                .Where(x => tagsRequest.All(y => y != x.Name))
                .ToList();
        }

        private List<string> SplitRequest(string request)
        {
            if (request != null)
            {
                var tags = request.ToLower().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                return new List<string>(tags);
            }
            return new List<string>();
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