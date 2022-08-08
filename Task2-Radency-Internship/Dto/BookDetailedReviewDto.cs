using Database.Models;

namespace Task2_Radency_Internship.Dto
{
    public class BookDetailedReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Cover { get; set; }
        public double Ratings { get; set; }
        public virtual List<ReviewDto> Reviews { get; set; }
        public static BookDetailedReviewDto ToDtoModel(Book book)
        {
           
            return new BookDetailedReviewDto()
            {
                Id = book.Id,
                Content = book.Content,
                Cover = book.Cover,
          
                Author = book.Author,
                Title = book.Title,
                Ratings = book.Ratings.Select(p => p.Score).DefaultIfEmpty().Average(),
                Reviews =book.Reviews.Select(p=>new ReviewDto()
                {
                    BookId  = p.BookId,
                    Id=p.Id,
                    Message = p.Message,
                    Reviewer = p.Reviewer,  

                }).ToList()
            };
        }

    }
}
