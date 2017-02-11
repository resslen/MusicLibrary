using System.Web.Mvc;

namespace MusicLibrary.Controllers
{
    public class TagsController : Controller
    {
        // GET: Tags
        public ActionResult Index()
        {
            return View();
        }
    }
}