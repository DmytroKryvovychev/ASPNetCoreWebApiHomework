using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace webapi.business.Domains
{
    public class Genre
    {
        private webapi.data.Repositories.Genre repository;
        private IMapper mapper;

        public Genre(IConfiguration configuration)
        {
            repository = new data.Repositories.Genre(configuration);
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<data.Entities.Genre, ViewModel.Genre>().ReverseMap(); //.ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books)).ReverseMap();
                cfg.CreateMap<data.Entities.Book, ViewModel.Book>().ForMember(dest => dest.Genre, opt => opt.Ignore()).ReverseMap();
            }).CreateMapper();
        }

        public IEnumerable<ViewModel.Genre> Get()
        {
            var genres = repository.Get();
            return genres.Select(genre => mapper.Map<data.Entities.Genre, ViewModel.Genre>(genre));
        }

        public IEnumerable<ViewModel.Book> GetBooksByCategory(string category)
        {
            var books = repository.GetBooksByCategory(category);
            return books.Select(book => mapper.Map<data.Entities.Book, ViewModel.Book>(book));
        }

        public ViewModel.Book DeleteBook(string category, int bookId)
        {
            var book = repository.DeleteBook(category, bookId);
            return mapper.Map<data.Entities.Book, ViewModel.Book>(book);
        }

        public ViewModel.Book AddBookInCategory(ViewModel.Book newBook)
        {
            var book = repository.AddBookInCategory(mapper.Map<ViewModel.Book, data.Entities.Book>(newBook));
            return mapper.Map<ViewModel.Book>(book);
        }

        public ViewModel.Book ChangeBook(ViewModel.Book newBook)
        {
            var book = repository.ChangeBook(mapper.Map<ViewModel.Book, data.Entities.Book>(newBook));
            return mapper.Map<ViewModel.Book>(book);
        }
    }
}