using my_book.Data.Models;
using my_book.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_book.Data.Services
{
	public class BooksServices
	{
		private AppDbContext _context;
		public BooksServices(AppDbContext context)
		{
			_context = context;
		}

		public void AddBook(BookVM book)
		{
			var _book = new Book()
			{
				Title = book.Title,
				Description = book.Description,
				IsRead = book.IsRead,
				DateRead = book.IsRead ? book.DateRead.Value : null,
				Rate = book.IsRead ? book.Rate.Value : null,
				Author = book.Author,
				CoverUrl = book.CoverUrl,
				Genre = book.Genre,
				DateAdded = DateTime.Now
			};

			_context.Add(_book);
			_context.SaveChanges();
		}

		public List<Book> GetAllBooks() => _context.Books.ToList();

		public Book GetBookByTitle(string title) => _context.Books.ToList().FirstOrDefault(n => n.Title == title);

		public Book GetBookById(int bookId) => _context.Books.ToList().FirstOrDefault(n => n.Id == bookId);

		public Book UpdateBookById(int bookdId, BookVM book) {
			var _book = _context.Books.FirstOrDefault(n => n.Id == bookdId);
			if (_book != null)
			{
				_book.Title = book.Title;
				_book.Description = book.Description;
				_book.IsRead = book.IsRead;
				_book.DateRead = book.IsRead ? book.DateRead.Value : null;
				_book.Rate = book.IsRead ? book.Rate.Value : null;
				_book.Author = book.Author;
				_book.CoverUrl = book.CoverUrl;
				_book.Genre = book.Genre;
				_book.DateAdded = DateTime.Now;

				_context.SaveChanges();
			}
			return _book;
		}

		public void DeleteBook(int bookId) {
			var _book = _context.Books.ToList().FirstOrDefault(n => n.Id == bookId);
			if (_book != null) {
				_context.Remove(_book);
				_context.SaveChanges();
			}
		}
	}
}
