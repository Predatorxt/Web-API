using FirstWebAPI.Data.Services;
using FirstWebAPI.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
          var AllBooks = _bookService.GetAllBooks();
            return Ok(AllBooks);
        }
        [HttpGet("Get-Book-By-Id/{id}")]
        public IActionResult GetAllBooks(int id)
        {
            var AllBooks = _bookService.Getbook(id);
            return Ok(AllBooks);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }
        [HttpPut("Update-Book-Id/{id}")]
        public IActionResult Update(int id,[FromBody]BookVM book)
        {
            var updatedbook = _bookService.UpdateBook(id, book);
            return Ok(updatedbook);
        }
        [HttpDelete("Delete-Book-Id/{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return Ok();

        }
    }

}
