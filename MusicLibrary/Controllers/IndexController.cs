using System.Web.Mvc;

namespace MusicLibrary.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Main page";
            return View();
        }
    }
}