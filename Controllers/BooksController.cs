using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_book.Data.Services;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//controller is used to receive HTTP request and respond with HTTP response
	public class BooksController : ControllerBase
	{
		public BooksServices _booksServices;

		public BooksController(BooksServices booksServices)
		{
			_booksServices = booksServices;
		}

		//httppost endpoint as it sends data to DB
		[HttpPost("add-book")]
		public IActionResult AddBook([FromBody]BookVM book) 
		{
			_booksServices.AddBook(book);
			return Ok();
		}

		[HttpGet("get-all-books")]
		public IActionResult GetAllBooks() {
			var allBooks = _booksServices.GetAllBooks();
			return Ok(allBooks);
		}

		// the bookid comes from HttpGet request.
		// {bookId} --> map the parameter with the method
		[HttpGet("get-book-by-id/{bookId}")]
		public IActionResult GetBookById(int bookId)
		{
			var book = _booksServices.GetBookById(bookId);
			return Ok(book);
		}

		[HttpGet("get-book-by-title/{title}")]
		public IActionResult GetBookByTitle(string title)
		{
			var book = _booksServices.GetBookByTitle(title);
			return Ok(book);
		}


		[HttpPut("update-book-by-id/{bookId}")]
		public IActionResult UpdateBookById(int bookId, [FromBody]BookVM book)
		{
			var _book = _booksServices.UpdateBookById(bookId,book);
			return Ok(_book);
		}

		[HttpDelete("delete-book/{bookId}")]
		public IActionResult DeleteBookById(int bookId)
		{
			_booksServices.DeleteBook(bookId);
			return Ok();
		}
	}
}
