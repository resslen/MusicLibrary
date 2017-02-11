using System.Web.Mvc;
using MusicLibrary.Filters;
using MusicLibrary.Models;
using MusicLibrary.Services;

namespace MusicLibrary.Controllers
{
    [ValidateInput(false)]
    [RoutePrefix("artists")]
    [HandleNotFoundException]
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _artistsService;
        private readonly IHelperService _helperService;

        public ArtistsController(IArtistsService artistsService, IHelperService helperService)
        {
            _artistsService = artistsService;
            _helperService = helperService;
        }

        [HttpGet, Route("")]
        public ActionResult Index()
        {
            ViewBag.Title = "Author list";
            var model = _artistsService.AllArtists();
            return View(model);
        }

        [HttpGet, Route("{id:int}")]
        public ActionResult Details(int id)
        {
            var model = _artistsService.ArtistById(id);
            ViewBag.Title = model.Name;
            return View(model);
        }

        [HttpGet, Route("{id:int}/delete")]
        public ActionResult Delete(int id)
        {
            var model = _artistsService.ArtistById(id);
            ViewBag.Title = model.Name;
            return View(model);
        }

        [HttpPost, Route("{id:int}/delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _artistsService.DeleteById(id);
            return RedirectToAction("Index");
        }

        [HttpGet, Route("add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost, Route("add")]
        public ActionResult AddConfirm(NewArtistViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = _helperService.ModelErrorsToString(ModelState);
                return View("Add");
            }
            var id = _artistsService.AddArtist(model);
            return RedirectToAction("Details", new { Id = id });
        }

        [HttpGet, Route("{id:int}/edit")]
        public ActionResult Edit(int id)
        {
            var model = _artistsService.ArtistById(id);
            return View("Edit", model);
        }

        [HttpPost, Route("{id:int}/edit")]
        public ActionResult EditSave(int id, NewArtistViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = _helperService.ModelErrorsToString(ModelState);
                return Edit(id);
            }
            _artistsService.UpdateArtist(id, model);
            return RedirectToAction("Details", new {Id = id});
        }
    }
}