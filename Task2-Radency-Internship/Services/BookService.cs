using Database.Models;
namespace Task2_Radency_Internship.Services
{
    public class BookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly IRepository<Rating> _ratingRepository;

        public BookService(IRepository<Book> bookRepository, IRepository<Review> reviewRepository, IRepository<Rating> ratingRepository)
        {
            _bookRepository = bookRepository;
            _reviewRepository = reviewRepository;
            _ratingRepository = ratingRepository;
        }
        public async Task<List<Book>> GetBooksAsync()
        {
            var result = await _bookRepository.GetAllAsync();
            return result;
        }
    }
}
