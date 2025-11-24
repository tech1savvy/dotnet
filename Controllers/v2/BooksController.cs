using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using Asp.Versioning;

namespace dotnet.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee" },
            new Book { Id = 3, Title = "1984", Author = "George Orwell" }
        };

        // GET: api/v2/books
        [HttpGet]
        public ActionResult<IEnumerable<BookDtoV2>> GetBooks()
        {
            var booksV2 = _books.Select(b => new BookDtoV2
            {
                Id = b.Id,
                FullTitle = $"{b.Title} by {b.Author}"
            }).ToList();

            return Ok(booksV2);
        }

        // GET: api/v2/books/5
        [HttpGet("{id}")]
        public ActionResult<BookDtoV2> GetBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var bookV2 = new BookDtoV2
            {
                Id = book.Id,
                FullTitle = $"{book.Title} by {book.Author}"
            };

            return Ok(bookV2);
        }

        // POST: api/v2/books
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() }, book);
        }

        // PUT: api/v2/books/5
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = _books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;

            return NoContent();
        }

        // DELETE: api/v2/books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _books.Remove(book);

            return NoContent();
        }
    }
}
