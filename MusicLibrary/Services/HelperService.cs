using System.Text;
using System.Web.Mvc;

namespace MusicLibrary.Services
{
    public class HelperService : IHelperService
    {
        public string ModelErrorsToString(ModelStateDictionary modelState)
        {
            var result = new StringBuilder();
            foreach (var field in modelState.Values)
            {
                foreach (var error in field.Errors)
                {
                    result.AppendLine(error.ErrorMessage);
                }
            }
            return result.ToString();
        }
    }
}