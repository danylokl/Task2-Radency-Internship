using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2_Radency_Internship.Dto;
using Task2_Radency_Internship.Services;
using System.Linq;
namespace Task2_Radency_Internship.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> Get()
        {
            var books = await _bookService.GetBooksAsync();

            var result= books.Select(book => BookDto.ToDtoModel(book)).ToList();

            return Ok(result);
            
            
            //return Ok(result.Select(book => BookDto.ToDtoModel(book)).ToList());
        }
    }
}
