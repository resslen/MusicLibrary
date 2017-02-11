using System;
using System.Collections.Generic;
using System.Linq;
using MusicLibrary.DAL;

namespace MusicLibrary.Services
{
    public class SortService : ISortService
    {
        public IQueryable<Artist> Sort(IQueryable<Artist> artists, string sortBy)
        {
            var result = artists.OrderBy(x => 0);
            if (sortBy == null)
            {
                return DefaultSort(result);
            }
            var sequence = Split(sortBy);
            foreach (var sortType in sequence)
            {
                result = Apply(result, sortType);
            }
            return result;
        }

        public IQueryable<Album> Sort(IQueryable<Album> albums, string sortBy)
        {
            var result = albums.OrderBy(x => 0);
            if (sortBy == null)
            {
                return DefaultSort(result);
            }
            var sequence = Split(sortBy);
            foreach (var sortType in sequence)
            {
                result = Apply(result, sortType);
            }
            return result;
        }

        private IOrderedQueryable<Album> DefaultSort(IOrderedQueryable<Album> albums)
        {
            return albums.ThenBy(x => x.Title)
                .ThenBy(x => x.Author.Name);
        }

        private IOrderedQueryable<Artist> DefaultSort(IOrderedQueryable<Artist> artists)
        {
            return artists.ThenBy(x => x.Name);
        }

        private IOrderedQueryable<Artist> Apply(IOrderedQueryable<Artist> result, string sortType)
        {
            switch (sortType)
            {
                case "name":
                    return result.ThenBy(x => x.Name);
                case "namedesc":
                    return result.ThenByDescending(x => x.Name);
                case "artists":
                    return result.ThenBy(x => x.AlbumCount);
                case "albumsdesc":
                    return result.ThenByDescending(x => x.AlbumCount);
                default:
                    return result;
            }
        }

        private IOrderedQueryable<Album> Apply(IOrderedQueryable<Album> result, string sortType)
        {
            switch (sortType)
            {
                case "title":
                    return result.ThenBy(x => x.Title);
                case "titledesc":
                    return result.ThenByDescending(x => x.Title);
                case "artist":
                    return result.ThenBy(x => x.Author.Name);
                case "artistdesc":
                    return result.ThenByDescending(x => x.Author.Name);
                case "year":
                    return result.ThenBy(x => x.Year);
                case "yeardesc":
                    return result.ThenByDescending(x => x.Year);
                default:
                    return result;
            }
        }

        private IEnumerable<string> Split(string sortBy)
        {
            return sortBy.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}