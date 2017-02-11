using System.Collections.Generic;
using MusicLibrary.DAL;

namespace MusicLibrary.Services
{
    public interface ITagsService
    {
        IEnumerable<Tag> GetTags(string sort = null, string search = null);
        void UpdateAlbumWithTags(Album album, string tags);
        void CleanTags();
        Tag GetTag(int id);
    }
}