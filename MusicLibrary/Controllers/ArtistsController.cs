using System.Web.Mvc;
using MusicLibrary.Services;

namespace MusicLibrary.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _artistsService;

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

        public ActionResult Details(int id)
        {
            var model = _artistsService.ArtistById(id);
            ViewBag.Title = model.Name;
            return View(model);
        }
    }
}