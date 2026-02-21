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
                Id = 1

            };
            return book;
        }


        [TestMethod]
        public void Add_AddsBook()
        {
            var book = CreateBook();

            var result = _service.AddBook(book);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, _service.GetAllBooks().Count());
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
                Id = 1
            };

            _service.AddBook(newBook);
            var result = _service.UpdateBook(updatedBook);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<Book>(result);

            Assert.AreEqual("Swedish Wood", result.Title);
            Assert.AreEqual("Haruki Murakami", result.Author);
            Assert.AreEqual(5, result.Rating);
            Assert.AreEqual("images/swedish-wood.jpeg", result.ImageUrl);
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
            for (var i = 0; i < 5; i++)
            {
                var book = CreateBook();
                _service.AddBook(book);
            }

            var result = _service.GetAllBooks();
            Assert.HasCount(5, result);
        }
    }
}