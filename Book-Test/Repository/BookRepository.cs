using Book_Test.Model;
using Book_Test.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Test.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public void UpdateBook(Book book)
        {
            var book2 = _context.Books.Where(x => x.Id == book.Id).AsNoTracking().FirstOrDefault();

            Book newBook = new Book
            {
                Author = (book.Author == null) ? book2.Author : book.Author,
                Title = (book.Title == null) ? book2.Title : book.Title
            };

            _context.Books.Update(newBook);
            _context.SaveChanges();
        }
    }
}
