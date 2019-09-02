using Book_Test.Model;
using System;
using System.Collections.Generic;

namespace Book_Test.Repository.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);

        void CreateBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(int id);
    }
}
