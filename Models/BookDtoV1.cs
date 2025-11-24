namespace dotnet.Models
{
    public class BookDtoV1
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public AuthorDto? Author { get; set; }
    }
}
