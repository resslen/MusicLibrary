using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using MusicLibrary.DAL;

namespace MusicLibrary.Helpers
{
    public static class TagsHelpers
    {
        public static MvcHtmlString ListTags(this HtmlHelper helper, IEnumerable<Tag> tags)
        {
            var result = new StringBuilder();
            foreach (var tag in tags)
            {
                result.Append(tag.Name + " ");
            }
            return new MvcHtmlString(result.ToString());
        }
    }
}
