using FirstWebAPI.Data.Models;
using FirstWebAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebAPI.Data.Services
{
    public class BookService
    {
        public AppDbContext _context;
        public BookService(AppDbContext context)
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
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                Dated = DateTime.Now

            };
            _context.books.Add(_book);
            _context.SaveChanges();

        }
        public List<Book> GetAllBooks() => _context.books.ToList();

        public Book Getbook(int BookId)
        {
            return _context.books.FirstOrDefault(n => n.Id == BookId);
        }
        public Book UpdateBook(int BookId,BookVM book)
        {
            var _book = _context.books.FirstOrDefault(n => n.Id == BookId);
            if (_book != null) {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            }
            return _book;
        }
        public void Delete(int BookId)
        {
            var _book = _context.books.FirstOrDefault(n => n.Id == BookId);
            if(_book!=null)
            {
                _context.books.Remove(_book);
                _context.SaveChanges();
            }

        }
      
    }
}
