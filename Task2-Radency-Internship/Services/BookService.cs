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
        public async Task<List<Book>> GetAllBooksAsync()
        {
            var result = await _bookRepository.GetAllAsync();
            return result;
        }
        public async Task<Book> GetBookAsync(int id)
        {
            var result = await _bookRepository.GetByIdAsync(id);
            return result;
        }
        public async Task DeleteBook(int id)
        {
            await _bookRepository.Remove(id);
        }
        public async Task CreateBook(Book book)
        {
            await _bookRepository.Create(book);    
        }
        public async Task UpdateBook(Book entity)
        {
           await  _bookRepository.Update(entity);
        }
        public async Task SaveChanges ()
        {
            await _bookRepository.SaveChanges();
        }
    }
}
