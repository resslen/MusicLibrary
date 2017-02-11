using System;
using System.Collections.Generic;
using System.Linq;
using MusicLibrary.DAL;

namespace MusicLibrary.Services
{
    public class SortService
    {
        public IQueryable<Artist> Sort(IQueryable<Artist> artists, string sortBy)
        {
            if (sortBy == null)
            {
                return artists;
            }
            var result = artists.OrderBy(x => 0);
            var sequence = Split(sortBy);
            foreach (var sortType in sequence)
            {
                Apply(result, sortType);
            }
            return result;
        }

        public IQueryable<Album> Sort(IQueryable<Album> albums, string sortBy)
        {
            if (sortBy == null)
            {
                return albums;
            }
            var result = albums.OrderBy(x => 0);
            var sequence = Split(sortBy);
            foreach (var sortType in sequence)
            {
                Apply(result, sortType);
            }
            return result;
        }

        private void Apply(IOrderedQueryable<Artist> result, string sortType)
        {
            switch (sortType)
            {
                case "name":
                    result = result.ThenBy(x => x.Name);
                    break;
                case "namedesc":
                    result = result.ThenByDescending(x => x.Name);
                    break;
                case "albums":
                    result = result.ThenBy(x => x.AlbumCount);
                    break;
                case "albumsdesc":
                    result = result.ThenByDescending(x => x.AlbumCount);
                    break;
            }
        }

        private void Apply(IOrderedQueryable<Album> result, string sortType)
        {
            switch (sortType)
            {
                case "title":
                    result = result.ThenBy(x => x.Title);
                    break;
                case "titledesc":
                    result = result.ThenByDescending(x => x.Title);
                    break;
                case "artist":
                    result = result.ThenBy(x => x.Author.Name);
                    break;
                case "artistdesc":
                    result = result.ThenByDescending(x => x.Author.Name);
                    break;
                case "year":
                    result = result.ThenBy(x => x.Year);
                    break;
                case "yeardesc":
                    result = result.ThenByDescending(x => x.Year);
                    break;
            }
        }

        private IEnumerable<string> Split(string sortBy)
        {
            return sortBy.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}