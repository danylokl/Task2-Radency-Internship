using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace Task2_Radency_Internship.Dto
{
    public class RatingDto
    {
        public int Id { get; set; }
      
        public int BookId { get; set; }
        [Required]
        [Range(1,5)]
        public double Score { get; set; }
        public static RatingDto ToDtoModel(Rating rating)
        {
            return new RatingDto()
            {
                BookId = rating.BookId,
                Id = rating.Id,
                Score = rating.Score
            };
        }
        public Rating ToModel()
        {
            return new Rating()
            {
                Id = Id,
                Score = Score,
                BookId = BookId
            };
        }
    }
}
