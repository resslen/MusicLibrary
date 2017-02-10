using System.Web.Mvc;
using MusicLibrary.Filters;
using MusicLibrary.Models;
using MusicLibrary.Services;

namespace MusicLibrary.Controllers
{
    [HandleNotFoundException]
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _artistsService;

        public ArtistsController(IArtistsService artistsService)
        {
            _artistsService = artistsService;
        }

        [Route("artists")]
        public ActionResult Index()
        {
            ViewBag.Title = "Artist list";
            var model = _artistsService.AllArtists();
            return View(model);
        }

        [Route("artists/{id:int}")]
        public ActionResult Details(int id)
        {
            var model = _artistsService.ArtistById(id);
            ViewBag.Title = model.Name;
            return View(model);
        }

        [HttpGet, Route("artists/{id:int}/delete")]
        public ActionResult Delete(int id)
        {
            var model = _artistsService.ArtistById(id);
            return View(model);
        }

        [HttpPost, Route("artists/{id:int}/delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _artistsService.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}