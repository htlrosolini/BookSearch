using BookSearch.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksController(BooksContext context)
        {
            Context = context;
        }

        public BooksContext Context { get; }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get([FromQuery] string property, [FromQuery] string value)
        {
            var books = await Context.Books.ToListAsync();

            switch (property.ToLower())
            {
                case "title":
                    return books.Where(b => b.Title == value);
                case "firstname":
                    return books.Where(b => b.FirstName == value );
                case "lastname":
                    return books.Where(b=> b.LastName == value );
                case "totalcopies":
                    return books.Where(b=> b.TotalCopies == Convert.ToInt32(value));
                case "copiesinuse":
                    return books.Where(b=>b.CopiesInUse == Convert.ToInt32(value));
                case "type":
                    return books.Where(b=> b.Type == value );
                case "isbn":
                    return books.Where(b => b.Isbn == value );
                case "category":
                    return books.Where(b => b.Category == value );
                default:
                    return books;
            }
        }             
    }
}                    

                      

                      

                     

                     