using System.ComponentModel.DataAnnotations;
using dotnet.Validation;

namespace dotnet.Models
{
    [TitleAuthorMustBeDifferent]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? Title { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Author { get; set; }
    }
}
