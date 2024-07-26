using System.ComponentModel.DataAnnotations;
using Para.Api.Model;

namespace Para.Api.Attribute;

public class PageCountAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var model = (Book)validationContext.ObjectInstance;
        var result = ValidationResult.Success;
        var pageCount = (int)value;
        return model.Year switch
        {
            >= 1900 and <= 1950 when pageCount > 100 => new ValidationResult(
                "Invalid page count for Year " + model.Year),
            >= 1951 and <= 1999 when pageCount > 200 => new ValidationResult(
                "Invalid page count for Year " + model.Year),
            _ => ValidationResult.Success
        };
    }
}