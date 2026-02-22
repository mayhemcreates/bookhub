using BookHub.Api.Models;
using BookHub.Api.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookHub.Tests.Services
{
    [TestClass]
    public class BooksServiceTest
    {

        private BooksService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new BooksService();
        }

        public Book CreateBook()
        {
            var book = new Book
            {
                Title = "Norwegian Wood",
                Author = "Haruki Murakami",
                ISBN = "1234567890",
                Rating = 3,
                NoteStatus = true,
                Comments = "a great book",
                ImageUrl = "images/norwegian-wood.jpeg",
                Id = GetNextId()

            };
            return book;
        }

        public int GetNextId()
        {
            return _service.GetAllBooks().Count() + 1;
        }


        [TestMethod]
        public void Add_AddsBook()
        {
            var book = CreateBook();
            var id = _service.GetAllBooks().Count() + 1;
            book.Id = id;

            var result = _service.AddBook(book);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(id, _service.GetAllBooks().Count());
            Assert.AreEqual("Norwegian Wood", result.Title);
        }


        [TestMethod]

        public void Get_GetsBook()
        {
            var book = CreateBook();
            _service.AddBook(book);
            var result = _service.GetBook(book.Id);

            Assert.IsInstanceOfType<Book>(result);
            Assert.AreEqual("Norwegian Wood", result.Title);

        }

        [TestMethod]
        public void Delete_RemovesBook()
        {
            var newBook = CreateBook();
            var book = _service.AddBook(newBook);
            var result = _service.DeleteBook(book.Id);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Update_UpdatesExistingBook()
        {

            var newBook = CreateBook();

            var updatedBook = new Book
            {
                Title = "Swedish Wood",
                Author = "Haruki Murakami",
                ISBN = "0987654321",
                Rating = 5,
                NoteStatus = true,
                Comments = "an even better book, love it",
                ImageUrl = "images/swedish-wood.jpeg",
                Id = GetNextId()
            };

            _service.AddBook(newBook);
            var result = _service.UpdateBook(updatedBook);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<Book>(result);
            Assert.AreEqual("Norwegian Wood", result.Title); // title should not be updated
            Assert.AreEqual(5, result.Rating);
            Assert.AreEqual("an even better book, love it", result.Comments);
        }

        [TestMethod]
        public void Update_InvalidRating_ReturnsNull()
        {
            var book = CreateBook();
            book.Rating = 6; // valid rating should be between 1 and 5

            var result = _service.UpdateBook(book);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAll_GetsAllBooks()
        {
            var CurrentCount = _service.GetAllBooks().Count();
            for (var i = 0; i < 5; i++)
            {
                var book = CreateBook();
                _service.AddBook(book);
            }

            var result = _service.GetAllBooks();
            Assert.HasCount(CurrentCount + 5, result);
        }

        [TestMethod]
        public void GetAll_CountLessThan25()
        {

            var books = _service.GetAllBooks();
            if (books.Count < 25)
            {
                for (var i = books.Count; i < 25; i++)
                {
                    var book = CreateBook();
                    _service.AddBook(book);
                }
            }

            var result = _service.GetAllBooks();
            var maxCount = 25;
            Assert.IsLessThanOrEqualTo(maxCount, result.Count);
        }

        [TestMethod]
        public void AddBooks_DoesntExceed25()
        {
            var existingBooks = _service.GetAllBooks().ToList();
            foreach (var book in existingBooks)
            {
                _service.DeleteBook(book.Id);
            }

            for (var i = 0; i < 25; i++)
            {
                var book = CreateBook();
                _service.AddBook(book);
            }

            Assert.AreEqual(25, _service.GetAllBooks().Count);

            // Try to add the 26th book - should throw InvalidOperationException
            var newBook = CreateBook();
            try
            {
                _service.AddBook(newBook);
                Assert.Fail("Expected InvalidOperationException was not thrown");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Cannot add more than 25 books.", ex.Message);
            }
        }

        [TestMethod]
        public void HasRating_CommentsRequired()
        {
            var book = CreateBook();
            book.Rating = 4;
            book.Comments = null;

            var result = _service.UpdateBook(book);

            Assert.IsNull(result);
        }
    }
}