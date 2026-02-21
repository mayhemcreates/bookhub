using BookHub.Api.Models;
using BookHub.Api.Interfaces;

namespace BookHub.Api.Services
{
    public class BooksService : IBooksService
    {
        private readonly List<Book> _books = new();

        public List<Book> GetAllBooks() => _books;
        public Book? GetBook(int id)
        {

        }
        public Book? AddBook(Book book)
        {
        }

        public Book? UpdateBook(Book newBook)
        {
        }

        public bool DeleteBook(int id)
        {
        }
    }
}
