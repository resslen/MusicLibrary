using System.Web.Mvc;
using MusicLibrary.Exceptions;

namespace MusicLibrary.Filters
{
    public class HandleNotFoundExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            if (exception.GetType() == typeof(NotFoundException))
            {
                filterContext.Result = new HttpNotFoundResult();
                filterContext.ExceptionHandled = true;
            }
        }
    }
}