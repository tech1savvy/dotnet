using System.ComponentModel.DataAnnotations;

namespace dotnet.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        // Foreign Key
        public int AuthorId { get; set; }

        // Navigation property
        public Author? Author { get; set; }
    }
}
