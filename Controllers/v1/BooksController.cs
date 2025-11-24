using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using Asp.Versioning;
using dotnet.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreContext _context;

        public BooksController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: api/v1/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDtoV1>>> GetBooks()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Select(b => new BookDtoV1
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author == null ? null : new AuthorDto { Id = b.Author.Id, Name = b.Author.Name }
                })
                .ToListAsync();
        }

        // GET: api/v1/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDtoV1>> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var bookDto = new BookDtoV1
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author == null ? null : new AuthorDto { Id = book.Author.Id, Name = book.Author.Name }
            };

            return Ok(bookDto);
        }

        // POST: api/v1/books
        [HttpPost]
        public async Task<ActionResult<BookDtoV1>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            await _context.Entry(book).Reference(b => b.Author).LoadAsync();

            var bookDto = new BookDtoV1
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author == null ? null : new AuthorDto { Id = book.Author.Id, Name = book.Author.Name }
            };

            return CreatedAtAction(nameof(GetBook), new { id = book.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() }, bookDto);
        }

        // PUT: api/v1/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Books.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/v1/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
