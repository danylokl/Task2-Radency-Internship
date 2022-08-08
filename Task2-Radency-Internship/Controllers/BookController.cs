using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2_Radency_Internship.Dto;
using Task2_Radency_Internship.Services;
using System.Linq;
namespace Task2_Radency_Internship.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly IConfiguration _config;

        public BookController(BookService bookService, IConfiguration config)
        {
            _bookService = bookService;
            _config = config;
        }

        [HttpGet]
        [Route("books")]
        public async Task<ActionResult<List<BookWithRatingDto>>> GetAllBooks(/*[FromQuery] */ string? order)
        {
            var books = await _bookService.GetAllBooksAsync();

            if (books.Count == 0)
            {
                return BadRequest("Library is empty");
            }

            var result = books.Select(book => BookWithRatingDto.ToDtoModel(book)).ToList();

            if (order == "author")
            {
                result.Sort((a, b) => string.Compare(a.Author, b.Author));
            }
            else
            if (order == "title")
            {
                result.Sort((a, b) => string.Compare(a.Title, b.Title));
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<BookWithRatingDto>>> Recommended(string? genre)
        {
            var books = await _bookService.GetAllBooksAsync();

            if (books.Count == 0)
            {
                return BadRequest("Library is empty");
            }

            var booksWithRating = books.Select(book => BookWithRatingDto.ToDtoModel(book)).ToList();
            var result = booksWithRating.OrderByDescending(book => book.Ratings).Where(p => p.ReviewsNumber > 2).Take(10).ToList();   //For testing purpose, required ReviewsNumber reduced to 2

            if (genre != null)
            {
                result = result.Where(p => p.Genre == genre).Select(a => a).ToList();
            }

            return Ok(result);
        }
   
        [HttpGet]
        [Route("books/{id}")]
        public async Task<ActionResult<List<BookDetailedReviewDto>>> GetBook(int id)
        {
            var books = await _bookService.GetBookAsync(id);

            if (books != null)
            {
                var result = BookDetailedReviewDto.ToDtoModel(books);
                return Ok(result);
            }

            return BadRequest($"Book with id: {id} don`t exist ");
        }

        [HttpDelete]
        [Route("books/{id}")]
        public async Task<ActionResult> DeleteBook(int id, string? secret)
        {
            var bookexist = await _bookService.GetBookAsync(id);
            if (bookexist != null)
            {

                if (secret == _config["SecretWord"])
                {
                    await _bookService.DeleteBook(id);
                }
                else
                {
                    return BadRequest("Incorrect secret word");
                }
            }

            return Accepted();
        }

        [HttpPost]
        [Route("books/save")]
        public async Task<ActionResult> CreateOrUpdate([FromBody] NewBookDto newBookDto)
        {
            var book = newBookDto.ToModel();
            var bookexist = await _bookService.GetBookAsync(newBookDto.Id);

            if (bookexist != null)
            {
                bookexist.Author = newBookDto.Author;
                bookexist.Cover = newBookDto.Cover;
                bookexist.Content = newBookDto.Content;
                bookexist.Title = newBookDto.Title;
                bookexist.Genre = newBookDto.Genre;
                await _bookService.SaveChanges();
            }
            else
            {
                await _bookService.CreateBook(book);
            }

            return Accepted(new { id = book.Id });
        }
      
        [HttpPut]
        [Route("books/{id}/[action]")]
        public async Task<ActionResult> Review(int id, [FromBody] ReviewDto reviewDto)
        {
            var bookexist = await _bookService.GetBookAsync(id);

            if (bookexist != null)
            {
                var review = reviewDto.ToModel();
                review.BookId = id;
                bookexist.Reviews.Add(review);
                await _bookService.SaveChanges();
                return Accepted(new { id = bookexist.Reviews.Last().Id });
            }

            return BadRequest($"Book with id: {id} don`t exist ");
        }

        [HttpPut]
        [Route("books/{id}/[action]")]
        public async Task<ActionResult> rate(int id, [FromBody] RatingDto ratingDto)
        {
            var bookexist = await _bookService.GetBookAsync(id);

            if (bookexist != null)
            {
                if (ratingDto.Score >= 1 && ratingDto.Score <= 5)
                {
                    var rate = ratingDto.ToModel();
                    rate.BookId = id;
                    bookexist.Ratings.Add(rate);
                    await _bookService.SaveChanges();
                }
                else
                {
                    return BadRequest("score must be between 1 and 5");
                }
            }
            else
            {
                return BadRequest($"Book with id: {id} don`t exist ");
            }

            return Accepted(new { id = bookexist.Ratings.Last().Id });
        }
    }
}
