using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace BuddyGuard.API.Models
{
    public class CustomDateTimeModelBinderProvider
        : IModelBinderProvider
    {
        public IModelBinder GetBinder(
            ModelBinderProviderContext context)
        {
            if (CustomDateTimeModelBinder
                .SUPPORTED_DATETIME_TYPES
                .Contains(context.Metadata.ModelType)
                )
            {
                return new BinderTypeModelBinder(
                    typeof(CustomDateTimeModelBinder));
            }
            return null;
        }
    }
}