using System.Web.Mvc;

namespace MusicLibrary.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}