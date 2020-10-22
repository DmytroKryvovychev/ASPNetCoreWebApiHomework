using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace webapi.business.Domains
{
    public class Book
    {
        private webapi.data.Repositories.Book repository;
        private IMapper mapper;

        public Book(IConfiguration configuration)
        {
            repository = new data.Repositories.Book(configuration);
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<data.Entities.Book, ViewModel.Book>();
                cfg.CreateMap<ViewModel.Book, data.Entities.Book>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModel.Book> Get()
        {
            var books = repository.Get();
            return books.Select(book => mapper.Map<data.Entities.Book, ViewModel.Book>(book));
        }
    }
}
