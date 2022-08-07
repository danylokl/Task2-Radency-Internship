using Database.Models;

namespace Task2_Radency_Internship.Dto
{
    public class NewBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public Book ToModel()
        {
            return new Book()
            {
                Id = Id,
                Title = Title,
                Cover = Cover,
                Content = Content,
                Author = Author,
                Genre = Genre,
                Ratings = new List<Rating>(),
                Reviews = new List<Review>()
            };
        }
    }
}
