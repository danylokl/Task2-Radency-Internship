using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Task2_Radency_Internship.Dto
{
    public class NewBookDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
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
