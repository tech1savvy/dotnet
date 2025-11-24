using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using Asp.Versioning;

namespace dotnet.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee" },
            new Book { Id = 3, Title = "1984", Author = "George Orwell" }
        };

        // GET: api/v1/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(_books);
        }

        // GET: api/v1/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/v1/books
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() }, book);
        }

        // PUT: api/v1/books/5
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

        // DELETE: api/v1/books/5
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
