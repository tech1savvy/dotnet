using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using Asp.Versioning;
using dotnet.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreContext _context;

        public BooksController(BookstoreContext context)
        {
            _context = context;
        }

        // GET: api/v2/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDtoV2>>> GetBooks()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Select(b => new BookDtoV2
                {
                    Id = b.Id,
                    FullTitle = $"{b.Title} by {b.Author!.Name}"
                })
                .ToListAsync();
        }

        // GET: api/v2/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDtoV2>> GetBook(int id)
        {
            var bookV2 = await _context.Books
                .Include(b => b.Author)
                .Where(b => b.Id == id)
                .Select(b => new BookDtoV2
                {
                    Id = b.Id,
                    FullTitle = $"{b.Title} by {b.Author!.Name}"
                })
                .FirstOrDefaultAsync();

            if (bookV2 == null)
            {
                return NotFound();
            }

            return Ok(bookV2);
        }

        // POST: api/v2/books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            await _context.Entry(book).Reference(b => b.Author).LoadAsync();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() }, book);
        }

        // PUT: api/v2/books/5
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

        // DELETE: api/v2/books/5
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
