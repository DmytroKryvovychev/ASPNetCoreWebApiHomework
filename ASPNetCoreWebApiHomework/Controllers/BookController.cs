using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webapi.business.Domains;

namespace ASPNetCoreWebApiHomework.Controllers
{
    //Here only all books get method
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private webapi.business.Domains.Book domain;

        public BookController(IConfiguration configuration)
        {
            domain = new webapi.business.Domains.Book(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = this.domain.Get();
            return Ok(books);
        }
    }
}
