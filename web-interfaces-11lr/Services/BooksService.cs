using System.Collections.Generic;
using System.Numerics;
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
            _books.Add(new Book { Id = 0, Title = "Book 1", Author = "Author 1", Price = 19.99m });
            _books.Add(new Book { Id = 1, Title = "Book 2", Author = "Author 2", Price = 24.99m });
            _books.Add(new Book { Id = 2, Title = "Book 3", Author = "Author 3", Price = 14.99m });
            _books.Add(new Book { Id = 3, Title = "Book 4", Author = "Author 4", Price = 29.99m });
            _books.Add(new Book { Id = 4, Title = "Book 5", Author = "Author 5", Price = 9.99m });
            _books.Add(new Book { Id = 5, Title = "Book 6", Author = "Author 6", Price = 12.99m });
            _books.Add(new Book { Id = 6, Title = "Book 7", Author = "Author 7", Price = 17.99m });
            _books.Add(new Book { Id = 7, Title = "Book 8", Author = "Author 8", Price = 21.99m });
            _books.Add(new Book { Id = 8, Title = "Book 9", Author = "Author 9", Price = 11.99m });
            _books.Add(new Book { Id = 9, Title = "Book 10", Author = "Author 10", Price = 15.99m });
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

