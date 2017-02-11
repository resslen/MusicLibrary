using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MusicLibrary.Helpers
{
    public static class ButtonHelpers
    {
        private static readonly object HtmlAttributes = new
            {
                @class = "waves-effect waves-light btn"
            };

        public static MvcHtmlString ActionButton(this HtmlHelper htmlHelper, string text, string action,
            object routeValues = null)
        {

            return htmlHelper.ActionLink(text, action, routeValues, HtmlAttributes);
        }

        public static MvcHtmlString ActionButton(this HtmlHelper htmlHelper, string text, string action,
            string controller, object routeValues)
        {
            return htmlHelper.ActionLink(text, action, controller, routeValues, HtmlAttributes);
        }
    }
}
