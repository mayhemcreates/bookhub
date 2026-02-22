using BookHub.Api.Models;

namespace BookHub.Api.Interfaces
{
    public interface IBooksService
    {
        List<Book> GetAllBooks();
        List<Book> SearchBooks(string query);
        Book? AddBook(Book book);
        Book? GetBook(int id);
        Book? UpdateBook(Book newBook);
        bool DeleteBook(int id);
    }
}