using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ASPNetCoreWebApiHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        //Here - all main CRUD methods with books
        private webapi.business.Domains.Genre domain;

        public GenreController(IConfiguration configuration)
        {
            domain = new webapi.business.Domains.Genre(configuration);
        }

        //Get all genres
        [HttpGet]
        public IActionResult Get()
        {
            var genres = this.domain.Get();
            return Ok(genres);
        }

        //Get all books in selected category
        [HttpGet("{category}")]
        [Route("{category}")]
        public IActionResult GetBooksByCategory([FromRoute] string category)
        {
            var books = this.domain.GetBooksByCategory(category);
            return Ok(books);
        }

        //Post book in the selected category, I know that "category" is unnecessary, it's only for me :)
        [HttpPost("{category}")]
        [Route("{category}")]
        public IActionResult AddBookInCategory([FromBody] webapi.business.ViewModel.Book newBook)
        {
            var book = this.domain.AddBookInCategory(newBook);
            return Ok(book);
        }

        //Change the selected book
        [HttpPut("{category}")]
        [Route("{category}")]
        public IActionResult ChangeBook([FromBody] webapi.business.ViewModel.Book newBook)
        {
            var book = this.domain.ChangeBook(newBook);
            return Ok(book);
        }

        //Delete the selected book, yes, I can delete by only id, I just decided to test this approach
        [HttpDelete("{category}/{id}")]
        [Route("{category}/{id}")]
        public IActionResult DeleteBook([FromRoute] string category, int id)
        {
            var book = this.domain.DeleteBook(category, id);
            return Ok(book);
        }
    }
}