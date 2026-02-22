using Microsoft.AspNetCore.Mvc;
using BookHub.Api.Models;
using BookHub.Api.Interfaces;

namespace BookHub.Api.Controllers
{

    [ApiController]
    [Route("api/bookStore")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var book = _service.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetAll(string sortBy = "title")
        {
            var books = _service.GetAllBooks(sortBy);
            return Ok(books);
        }

        [HttpPost("add")]
        public IActionResult AddBook([FromBody] Book book)
        {
            var addedBook = _service.AddBook(book);
            if (addedBook == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = addedBook.Id }, addedBook);
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string query)
        {
            var books = _service.SearchBooks(query ?? string.Empty);
            return Ok(books);
        }

        [HttpPut("edit/{id}")]
        public IActionResult EditBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var success = _service.UpdateBook(book);
            if (success != null && success is Book)
            {
                return Ok(success);
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var success = _service.DeleteBook(id);

            if (!success)
            {
                return BadRequest();
            }
            ;
            return Ok(true);
        }

    }
}