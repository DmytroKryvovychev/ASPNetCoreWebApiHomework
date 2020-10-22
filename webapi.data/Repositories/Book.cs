using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace webapi.data.Repositories
{
    public class Book
    {
        private WebApiDbContext context;


        public Book(IConfiguration configuration)
        {
            context = new WebApiDbContext(configuration);
        }

        public IEnumerable<Entities.Book> Get()
        {
            var books = context.Books.ToList();
            return books;
        }
    }
}
