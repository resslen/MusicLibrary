using System.Web.Mvc;
using MusicLibrary.Filters;
using MusicLibrary.Services;

namespace MusicLibrary.Controllers
{
    [ValidateInput(false)]
    [RoutePrefix("albums")]
    [HandleNotFoundException]
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService _albumsService;
        private readonly IHelperService _helperService;

        public AlbumsController(IAlbumsService albumsService, IHelperService helperService)
        {
            _albumsService = albumsService;
            _helperService = helperService;
        }

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            ViewBag.Title = "Album list";
            var model = _albumsService.AllAbums();
            return View(model);
        }

        [HttpGet, Route("{id:int}")]
        public ActionResult Details(int id)
        {
            var model = _albumsService.AlbumById(id);
            ViewBag.Title = model.Title;
            return View(model);
        }
    }
}