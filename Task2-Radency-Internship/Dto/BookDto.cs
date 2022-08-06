using Database.Models;

namespace Task2_Radency_Internship.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public string Genre { get; set; }
        public virtual List<RatingDto> Ratings { get; set; }
        public virtual List<ReviewDto> Reviews { get; set; }
        public static BookDto ToDtoModel(Book book)
        {
           
            return new BookDto()
            {
                Id = book.Id,
                Content = book.Content,
                Cover = book.Cover,
                Genre = book.Genre,
                Title = book.Title,
                Ratings=book.Ratings.Select(p=>new RatingDto()
                {
                    BookId = p.BookId,
                    Id = p.Id,
                    Score = p.Score
                }).ToList(),
                Reviews=book.Reviews.Select(p=>new ReviewDto()
                {
                    BookId  = p.BookId,
                    Id=p.Id,
                    Message = p.Message,
                    Reviewer = p.Reviewer,  

                }).ToList()
            };
        }
        public Book ToModel()
        {
            return new Book()
            {
                Title = Title,
                Genre = Genre,
                Cover = Cover,
                Content = Content,
                Id = Id
            };
        }
    }
}
