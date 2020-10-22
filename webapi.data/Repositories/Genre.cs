using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.data.Repositories
{
    public class Genre
    {
        private WebApiDbContext context;

        public Genre(IConfiguration configuration)
        {
            context = new WebApiDbContext(configuration);
        }

        public IEnumerable<Entities.Genre> Get()
        {
            var genres = context.Genres.Include(g => g.Books).ToList();
            return genres;
        }

        public async Task<IEnumerable<Entities.Book>> GetAllBooks()
        {
            var books = new List<Entities.Book>();
            await context.Genres.Include(g => g.Books).ForEachAsync(b =>
                {
                    foreach (var book in b.Books)
                    {
                        books.Add(book);
                    }
                }

            );
            return books;
        }

        public IEnumerable<Entities.Book> GetBooksByCategory(string category)
        {
            var d = context.Genres.Include(g => g.Books).FirstOrDefault(g => g.Title == category);
            var books = d.Books.ToList();
            return books;
        }

        public Entities.Book DeleteBook(string category, int bookId)
        {
            var book = context.Genres.Include(g => g.Books).FirstOrDefault(g => g.Title == category).Books.FirstOrDefault(b => b.Id == bookId);
            context.Books.Remove(book);
            context.SaveChanges();
            return book;
        }

        public Entities.Book AddBookInCategory(Entities.Book newBook)
        {
            context.Books.Add(newBook);
            context.SaveChanges();
            return newBook;
        }

        public Entities.Book ChangeBook(Entities.Book newBook)
        {
            //var book = context.Books.FirstOrDefault(b => b.Id == newBook.Id);
            context.Books.Update(newBook);
            context.SaveChanges();
            return newBook;
        }
    }
}