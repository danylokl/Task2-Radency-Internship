using Database.Models;

namespace Task2_Radency_Internship.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int BookId { get; set; }
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
