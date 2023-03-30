using FluentValidation;

namespace BaseProject.Infrastructure.Extensions;

public static class FluentValidationExtensions
{
    public static Func<object,string, Task<IEnumerable<string>>> ValidateValue<TModel>(
        this IValidator<TModel> validator)
    where TModel: class, new()
    {
        return async (model, propertyName) =>
        {
            var context = ValidationContext<TModel>
                .CreateWithOptions((TModel) model, o 
                    => o.IncludeProperties(propertyName));
                    
            var result = await validator.ValidateAsync(context);

            if (result.IsValid)
                return Array.Empty<string>();
            
            return result.Errors
                .Select(e => e.ErrorMessage);
        };
    }
}