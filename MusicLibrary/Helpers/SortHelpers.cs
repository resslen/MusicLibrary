using System.Web.Mvc;

namespace MusicLibrary.Helpers
{
    public static class SortHelpers
    {
        public static MvcHtmlString SortButtons(this HtmlHelper helper, string sortType)
        {
            var result = $"<a href=\"?sort={sortType + "desc"}\"><i class=\"material-icons tiny\">call_received</i></a>"
                         + $"<a href=\"?sort={sortType}\"><i class=\"material-icons tiny\">call_made</i></a>";
            return new MvcHtmlString(result);
        }
    }
}
