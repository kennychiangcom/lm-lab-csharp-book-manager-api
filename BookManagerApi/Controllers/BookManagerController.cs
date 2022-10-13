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

        private object ExceptionResponse(long errCode, long? bookId)
        {
            return new { ID = errCode, error = errCode switch 
                {
                    1 => "No books exist in the database yet.",
                    2 => $"Book id {bookId} does not exist.",
                    3 => $"Book id {bookId} does not exist and no update has been performed.",
                    4 => $"Book id {bookId} already exists and no overlapping of book id is possible.",
                    5 => $"Book id {bookId} does not exist and no deletion has been made.",
                    _ => ""
                }
            };
        }

        public BookManagerController(IBookManagementService bookManagementService)
        {
            _bookManagementService = bookManagementService;
        }

        // GET: api/v1/book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookManagementService.GetAllBooks();
            return books.Count > 0 ? books : NotFound(ExceptionResponse(1, null));
        }

        // GET: api/v1/book/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(long id)
        {
            var book = _bookManagementService.FindBookById(id);
            return book != null ? book : NotFound(ExceptionResponse(2, id));
        }

        // PUT: api/v1/book/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateBookById(long id, Book book)
        {
            return _bookManagementService.Update(id, book) != null ? NoContent() : NotFound(ExceptionResponse(3, id));
        }

        // POST: api/v1/book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            return _bookManagementService.Create(book) == book ? CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book) : NotFound(ExceptionResponse(4, book.Id));
        }

        // DELETE: api/v1/book/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(long id)
        {
            return _bookManagementService.DeleteBook(id) ? NoContent() : NotFound(ExceptionResponse(5, id));
        }
    }
}
