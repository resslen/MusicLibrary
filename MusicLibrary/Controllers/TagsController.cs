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
    }
}