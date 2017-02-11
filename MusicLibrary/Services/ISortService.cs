using System.Linq;
using MusicLibrary.DAL;

namespace MusicLibrary.Services
{
    public interface ISortService
    {
        IQueryable<Artist> Sort(IQueryable<Artist> artists, string sortBy);
        IQueryable<Album> Sort(IQueryable<Album> albums, string sortBy);
    }
}