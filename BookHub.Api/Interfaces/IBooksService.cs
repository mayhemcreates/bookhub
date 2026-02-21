using BookHub.Api.Models;

namespace BookHub.Api.Interfaces
{
    public interface IBooksService
    {
        List<Book> GetAllBooks();
        Book? AddBook(Book book);
        Book? GetBook(int id);
        Book? UpdateBook(Book newBook);
        bool DeleteBook(int id);
    }
}