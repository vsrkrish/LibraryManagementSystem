using LibraryManagementSystem.DBLayer;
using LibraryManagementSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryContext _context;

        public BooksController(ILibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks() =>
            await _context.Books.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooks), new { id = book.BookId }, book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book updatedBook)
        {
           

            var book = await _context.Books.FindAsync(updatedBook.BookId);
            if (book == null)
                return NotFound();

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.ISBN = updatedBook.ISBN;
            book.IsAvailable = updatedBook.IsAvailable;
            book.Stock = updatedBook.Stock;
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
