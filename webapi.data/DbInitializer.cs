using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi.data.Entities;

namespace webapi.data
{
    public static class DbInitializer
    {
        public static void Initialize(WebApiDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Genres.Any())
            {
                context.Genres.Add(new Genre()
                {
                    Title = "fantasy",
                    Books = new List<Entities.Book>()
                    {
                        new Entities.Book
                        {
                            Title = "A Game of Thrones", Author = "George R. R. Martin", PublicationYear = 2000,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "The Fellowship of the Ring", Author = "J. R. R. Tolkien", PublicationYear = 2000,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "The Lion, the Witch and the Wardrobe", Author = "C. S. Lewis",
                            PublicationYear = 2000, PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "Prince of Thorns", Author = "Mark Lawrence", PublicationYear = 2000,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "American Gods", Author = "Neil Gaiman", PublicationYear = 2000,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "Harry Potter and the Sorcerer’s Stone", Author = "J. K. Rowling",
                            PublicationYear = 2000, PublisherName = "Expo"
                        },
                    }
                });
                context.Genres.Add(new Genre()
                {
                    Title = "sci-fi",
                    Books = new List<Entities.Book>()
                    {
                        new Entities.Book
                        {
                            Title = "Kindred", Author = "Octavia E. Butler", PublicationYear = 1979,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "Jurassic Park", Author = "Michael Crichton", PublicationYear = 1990,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "Foundation", Author = "Isaac Asimov",
                            PublicationYear = 1951, PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "Solaris", Author = "Stanislaw Lem", PublicationYear = 1961,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "The Moon is a Harsh Mistress", Author = "Robert Heinlein", PublicationYear = 1966,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "Hyperion", Author = "Dan Simmons",
                            PublicationYear = 1989, PublisherName = "Expo"
                        },
                    }
                });
                context.Genres.Add(new Genre()
                {
                    Title = "adventure",
                    Books = new List<Entities.Book>()
                    {
                        new Entities.Book
                        {
                            Title = "The Three Musketeers", Author = "Alexandre Dumas", PublicationYear = 1979,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "Treasure Island", Author = "Robert Louis Stevenson", PublicationYear = 1990,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "Journey to the Center of the Earth", Author = "Jules Verne",
                            PublicationYear = 1951, PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "Heart of Darkness", Author = "Joseph Conrad", PublicationYear = 1961,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "The Jungle Book", Author = "Rudyard Kipling", PublicationYear = 1966,
                            PublisherName = "Expo"
                        },
                        new Entities.Book
                        {
                            Title = "The Lost World", Author = "Sir Arthur Conan Doyle",
                            PublicationYear = 1989, PublisherName = "Expo"
                        },
                    }
                });
            }

            context.SaveChanges();

        }
    }
}
