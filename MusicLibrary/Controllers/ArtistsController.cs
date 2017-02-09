using System.Web.Mvc;
using MusicLibrary.Services;

namespace MusicLibrary.Controllers
{
    public class ArtistsController : Controller
    {
        private IArtistsService _artistsService;

        public ArtistsController(IArtistsService artistsService)
        {
            _artistsService = artistsService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Artist list";
            var model = _artistsService.AllArtists();
            return View(model);
        }
    }
}