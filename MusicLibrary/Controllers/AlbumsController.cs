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

        public AlbumsController(IAlbumsService albumsService, IHelperService helperService, IArtistsService artistsService)
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

        [HttpGet, Route("add")]
        public ActionResult Add()
        {
            ViewBag.Title = "Add album";
            var model = _albumsService.GetAddViewModel();
            return View("Add", model);
        }

        [HttpPost, Route("add")]
        public ActionResult AddConfirmed(NewAlbumViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = _helperService.ModelErrorsToString(ModelState);
                return Add();
            }
            var id = _albumsService.AddAlbum(model);
            return RedirectToAction("Details", new {Id = id});
        }

        [HttpGet, Route("{id:int}/delete")]
        public ActionResult Delete(int id)
        {
            var model = _albumsService.AlbumById(id);
            ViewBag.Title = model.Title;
            return View(model);
        }

        [HttpPost, Route("{id:int}/delete")]
        public ActionResult DeleteConfirm(int id)
        {
            _albumsService.DeleteById(id);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("{id:int}/edit")]
        public ActionResult Edit(int id)
        {
            var model = _albumsService.GetEditViewModel(id);
            ViewBag.Title = model.Album.Title;
            return View("Edit", model);
        }

        [HttpPost, Route("{id:int}/edit")]
        public ActionResult EditConfirm(int id, NewAlbumViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = _helperService.ModelErrorsToString(ModelState);
                return Edit(id);
            }
            _albumsService.UpdateAlbum(id, model);
            return RedirectToAction("Details", new { Id = id });
        }
    }
}