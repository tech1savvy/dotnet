using System.ComponentModel.DataAnnotations;

namespace dotnet.Validation
{
    public class TitleAuthorMustBeDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var book = validationContext.ObjectInstance as Models.Book;

            if (book != null)
            {
                if (book.Title == book.Author)
                {
                    return new ValidationResult("Title and Author cannot be the same.", new[] { nameof(book.Title), nameof(book.Author) });
                }
            }

            return ValidationResult.Success;
        }
    }
}
