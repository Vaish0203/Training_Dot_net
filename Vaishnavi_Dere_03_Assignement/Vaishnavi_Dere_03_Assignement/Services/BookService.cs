using System.Collections.Generic;
using System.Linq;
using Vaishnavi_Dere_03_Assignement.Models;

namespace Vaishnavi_Dere_03_Assignement.Services
{
    public class BookService
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public Book GetBookById(string uid) => books.FirstOrDefault(b => b.UId == uid);

        public List<Book> GetBooksByName(string name)
        {
            return books.Where(b => b.Title.Contains(name)).ToList();
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public List<Book> GetAvailableBooks()
        {
            return books.Where(b => !b.IsIssued).ToList();
        }

        public List<Book> GetIssuedBooks()
        {
            return books.Where(b => b.IsIssued).ToList();
        }

        public void UpdateBook(Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.UId == updatedBook.UId);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.PublishedDate = updatedBook.PublishedDate;
                book.ISBN = updatedBook.ISBN;
                book.IsIssued = updatedBook.IsIssued;
            }
        }
    }
}
