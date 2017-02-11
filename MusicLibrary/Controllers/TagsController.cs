using System.Web.Mvc;
using MusicLibrary.Filters;
using MusicLibrary.Services;

namespace MusicLibrary.Controllers
{
    [ValidateInput(false)]
    [RoutePrefix("tags")]
    [HandleNotFoundException]
    public class TagsController : Controller
    {
        private readonly TagsService _tagsService;

        public TagsController(TagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpGet, Route("")]
        public ActionResult Index(string sort, string search)
        {
            var model = _tagsService.GetTags(sort, search);
            return View(model);
        }

        [HttpGet, Route("clean")]
        public ActionResult Clean()
        {
            _tagsService.CleanTags();
            return RedirectToAction("Index");
        }

        [HttpGet, Route("albums")]
        public ActionResult Albums(int id)
        {
            var tag = _tagsService.GetTag(id);
            return View(tag);
        }
    }
}