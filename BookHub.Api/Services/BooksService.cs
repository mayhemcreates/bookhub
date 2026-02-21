using BookHub.Api.Models;
using BookHub.Api.Interfaces;

namespace BookHub.Api.Services
{
    public class BooksService : IBooksService
    {
        // In-memory data storage for demo purposes only 
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        public BooksService()
        {
            // Seed with book instances while data isn't persisted in a database
            SeedData();
        }

        public List<Book> GetAllBooks() => _books;

        public Book? GetBook(int id)
        {
            var book = _books.FirstOrDefault(x => x.Id == id);
            if (book == null) return null;
            return book;
        }

        public Book? AddBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? UpdateBook(Book newBook)
        {
            var book = GetBook(newBook.Id);
            if (book == null) return null;
            book.Author = newBook.Author;
            book.Title = newBook.Title;
            book.ISBN = newBook.ISBN;
            book.NoteStatus = newBook.NoteStatus;
            book.Comments = newBook.Comments;
            book.ImageUrl = newBook.ImageUrl;
            book.Rating = newBook.Rating;
            return book;
        }

        public bool DeleteBook(int id)
        {
            var book = GetBook(id);
            if (book == null) return false;
            _books.Remove(book);
            return true;
        }

        private void SeedData()
        {
            AddBook(new Book
            {
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                ISBN = "978-0743273565",
                Rating = 5,
                NoteStatus = true,
                Comments = "A classic novel about the American Dream.",
                ImageUrl = "https://example.com/great-gatsby.jpg"
            });

            AddBook(new Book
            {
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                ISBN = "978-0061120084",
                Rating = 3,
                NoteStatus = true,
                Comments = "A powerful story about racial injustice.",
                ImageUrl = "https://example.com/to-kill-a-mockingbird.jpg"
            });
            AddBook(new Book
            {
                Title = "Great Expectations",
                Author = "Charles Dickens",
                ISBN = "978-0141439563",
                Rating = 4,
                NoteStatus = true,
                Comments = "A classic novel about personal growth and social criticism.",
                ImageUrl = "https://example.com/great-expectations.jpg"
            });
            AddBook(new Book
            {
                Title = "One Hundred Years of Solitude",
                Author = "Gabriel Garcia Marquez",
                ISBN = "978-0060883287",
                Rating = 5,
                NoteStatus = true,
                Comments = "A classic novel about magical realism and the Buendía family's saga.",
                ImageUrl = "https://example.com/one-hundred-years-of-solitude.jpg"
            });
            AddBook(new Book
            {
                Title = "Wuthering Heights",
                Author = "Emily Brontë",
                ISBN = "978-0141439556",
                Rating = 5,
                NoteStatus = true,
                Comments = "A classic novel about the intense and tragic love story of Heathcliff and Catherine.",
                ImageUrl = "https://example.com/wuthering-heights.jpg"
            });
            AddBook(new Book
            {
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                ISBN = "978-0316769488",
                Rating = 4,
                NoteStatus = true,
                Comments = "A classic novel about teenage rebellion and alienation.",
                ImageUrl = "https://example.com/the-catcher-in-the-rye.jpg"
            });
            AddBook(new Book
            {
                Title = "C# for Dummies",
                Author = "Stephen Randy Davis",
                ISBN = "978-1119527070",
                Rating = 4,
                NoteStatus = true,
                Comments = "A beginner's guide to learning C# programming.",
                ImageUrl = "https://example.com/csharp-for-dummies.jpg"
            });
        }
    }
}
