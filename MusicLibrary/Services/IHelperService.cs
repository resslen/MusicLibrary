using System.Web.Mvc;

namespace MusicLibrary.Services
{
    public interface IHelperService
    {
        string ModelErrorsToString(ModelStateDictionary modelState);
    }
}
