using System.Web.Mvc;
using MusicLibrary.Services;

namespace MusicLibrary.Controllers
{

    public class AlbumsController : Controller
    {
        private readonly IAlbumsService _albumsService;
        private readonly IHelperService _helperService;

        public AlbumsController(IAlbumsService albumsService, IHelperService helperService)
        {
            _albumsService = albumsService;
            _helperService = helperService;
        }
    }
}