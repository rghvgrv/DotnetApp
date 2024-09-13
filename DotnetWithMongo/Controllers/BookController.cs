using DotnetWithMongo.Model;
using DotnetWithMongo.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetWithMongo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BooksServices _booksServices;

        public BookController(BooksServices booksServices)
        {
            _booksServices = booksServices;
        }

        [HttpGet]
        public async Task<List<Book>> GetBooks() => await _booksServices.GetBooksAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _booksServices.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }
    }
}
