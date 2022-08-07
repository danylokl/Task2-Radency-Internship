using Database.Models;
namespace Task2_Radency_Internship.Dto
{
    public class BookWithRatingDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public double Ratings { get; set; }
        public double ReviewsNumber { get; set; }
        public static BookWithRatingDto ToDtoModel(Book book)
        {

            return new BookWithRatingDto()
            {
                Id = book.Id,
                Genre = book.Genre,
                Author = book.Author,
                Title = book.Title,
                Ratings = book.Ratings.Select(p=>p.Score).DefaultIfEmpty().Average(),
                ReviewsNumber  =book.Reviews.Count()
            };
        }
        
    }
}
