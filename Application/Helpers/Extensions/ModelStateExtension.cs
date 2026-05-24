using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Application.Helpers.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetModelStateErrors(this ModelStateDictionary dictionry)
        {
            var errors = dictionry.SelectMany(x => x.Value?.Errors).Select(x => x.ErrorMessage).ToList();
            return errors;
        }
    }
}
