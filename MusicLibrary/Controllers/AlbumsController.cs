using System.Linq;
using System.Web.Mvc;
using MusicLibrary.Filters;
using MusicLibrary.Models;
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
        private readonly IArtistsService _artistsService;

        public AlbumsController(IAlbumsService albumsService, IHelperService helperService, IArtistsService artistsService)
        {
            _albumsService = albumsService;
            _helperService = helperService;
            _artistsService = artistsService;
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

        [HttpGet, Route("add")]
        public ActionResult Add()
        {
            ViewBag.Title = "Add album";
            var model = new AddAlbumViewModel();
            model.Artists = _artistsService.AllArtists();
            model.AuthorId = model.Artists.First().Id;
            return View(model);
        }

        [HttpPost, Route("add")]
        public ActionResult AddConfirmed(NewAlbumViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = _helperService.ModelErrorsToString(ModelState);
                return View("Add");
            }
            var id = _albumsService.AddAlbum(model);
            return RedirectToAction("Details", new {Id = id});
        }
    }
}