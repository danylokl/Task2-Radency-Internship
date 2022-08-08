using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Task2_Radency_Internship.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        public int BookId { get; set; }
        [Required]
        public string Reviewer { get; set; }
        public Review ToModel()
        {
            return new Review()
            {
                Id = Id,
                Message = Message,
                BookId = BookId,
                Reviewer = Reviewer
            };
        }
    }
}
