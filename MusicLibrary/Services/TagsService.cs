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
    }
}