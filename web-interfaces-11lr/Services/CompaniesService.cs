using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6lr
{
    public interface IBooksService
    {
        Task<List<Book>> GetBooks();
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }

    public class BooksService : IBooksService
    {
        private readonly List<Book> _books = new List<Book>();

        public BooksService()
        {
            _books.Add(new Book { Id = 0, Title = "Book 1", Author = "Author 1", Publisher = "Publisher 1", Year = 2020 });
            _books.Add(new Book { Id = 1, Title = "Book 2", Author = "Author 2", Publisher = "Publisher 2", Year = 2019 });
            _books.Add(new Book { Id = 2, Title = "Book 3", Author = "Author 3", Publisher = "Publisher 3", Year = 2018 });
            _books.Add(new Book { Id = 3, Title = "Book 4", Author = "Author 4", Publisher = "Publisher 4", Year = 2017 });
            _books.Add(new Book { Id = 4, Title = "Book 5", Author = "Author 5", Publisher = "Publisher 5", Year = 2016 });
            _books.Add(new Book { Id = 5, Title = "Book 6", Author = "Author 6", Publisher = "Publisher 6", Year = 2015 });
            _books.Add(new Book { Id = 6, Title = "Book 7", Author = "Author 7", Publisher = "Publisher 7", Year = 2014 });
            _books.Add(new Book { Id = 7, Title = "Book 8", Author = "Author 8", Publisher = "Publisher 8", Year = 2013 });
            _books.Add(new Book { Id = 8, Title = "Book 9", Author = "Author 9", Publisher = "Publisher 9", Year = 2012 });
            _books.Add(new Book { Id = 9, Title = "Book 10", Author = "Author 10", Publisher = "Publisher 10", Year = 2011 });
        }

        public async Task<List<Book>> GetBooks()
        {
            return _books;
        }

        public async Task AddBook(Book book)
        {
            _books.Add(book);
        }

        public async Task UpdateBook(Book book)
        {
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index != -1)
            {
                _books[index] = book;
            }
        }

        public async Task DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}

