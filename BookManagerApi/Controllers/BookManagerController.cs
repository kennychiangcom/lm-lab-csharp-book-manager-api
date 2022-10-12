using Microsoft.AspNetCore.Mvc;
using BookManagerApi.Models;
using BookManagerApi.Services;

namespace BookManagerApi.Controllers
{
    [Route("api/v1/book")]
    [ApiController]
    public class BookManagerController : ControllerBase
    {
        private readonly IBookManagementService _bookManagementService;

        public BookManagerController(IBookManagementService bookManagementService)
        {
            _bookManagementService = bookManagementService;
        }

        // GET: api/v1/book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookManagementService.GetAllBooks();
            if (books.Count > 0) return books;
            return NotFound(new {Id = 1, error = "No books exist in the database yet."});
        }

        // GET: api/v1/book/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(long id)
        {
            var book = _bookManagementService.FindBookById(id);
            if (book != null) return book;
            return NotFound(new {Id = 2, error = $"Book id {id} does not exist."});
        }

        // PUT: api/v1/book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateBookById(long id, Book book)
        {
            var updatedBook = _bookManagementService.Update(id, book);
            if(updatedBook != null) return NoContent();
            return NotFound(new {Id = 3, error = $"Book id {id} does not exist and no update has been performed."});
        }

        // POST: api/v1/book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            if (_bookManagementService.Create(book) == book) return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            return NotFound(new { Id = 4, error = $"Book id {book.Id} already exists and no overlapping of book id is possible." });
        }

        // DELETE: api/v1/book/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(long id)
        {
            bool bookDeleted = _bookManagementService.DeleteBook(id);
            if (bookDeleted) return NoContent();
            return NotFound(new { Id = 5, error = $"Book id {id} does not exist and no deletion has been made." });
        }
    }
}
