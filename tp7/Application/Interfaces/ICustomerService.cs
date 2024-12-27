using tp7.Application.DTOs;

namespace tp7.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetCustomerById(Guid id);
        Task<CustomerDTO> CreateCustomer(CustomerDTO customer);
        Task<IEnumerable<MovieDTO>> GetFavoriteMovies(Guid customerId);

        Task<IEnumerable<MovieReviewDTO>> GetMovieReviews(Guid customerId);
        Task<IEnumerable<CustomerDTO>> GetAllCustomers();
        Task<CustomerDTO> UpdateCustomer(CustomerDTO customer);
        Task<CustomerDTO> DeleteCustomer(Guid id);
    }
}
