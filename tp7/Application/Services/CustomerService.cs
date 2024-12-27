using AutoMapper;
using tp7.Application.DTOs;
using tp7.Application.Interfaces;
using tp7.Domain.Entities;
using tp7.Domain.RepositoryInterfaces;

namespace tp7.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> GetCustomerById(Guid id)
        {
            var customer =
                await _customerRepository.GetById(id)
                ?? throw new KeyNotFoundException("Customer not found");
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> CreateCustomer(CustomerDTO customer)
        {
            var newCustomer = new Customer { Name = customer.Name };

            await _customerRepository.Add(newCustomer);

            return _mapper.Map<CustomerDTO>(newCustomer)
                ?? throw new Exception("Customer not created");
        }

        public async Task<IEnumerable<MovieDTO>> GetFavoriteMovies(Guid customerId)
        {
            var favoriteMovies = await _customerRepository.GetFavoriteMovies(customerId);
            return favoriteMovies.Select(movie => new MovieDTO
            {
                Id = movie.Id,
                Name = movie.Name,
                Genre = new GenreDTO { Id = movie.Genre.Id, Name = movie.Genre.Name },
                Reviews = movie.Reviews.Select(review => new MovieReviewDTO
                {
                    Id = review.Id,
                    Comment = review.Comment,
                    Rating = review.Rating,
                }),
            });
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO customer)
        {
            var customerToUpdate =
                await _customerRepository.GetById(customer.Id)
                ?? throw new KeyNotFoundException("Customer not found");

            customerToUpdate.Name = customer.Name;

            await _customerRepository.Update(customerToUpdate);

            return _mapper.Map<CustomerDTO>(customerToUpdate)
                ?? throw new Exception("Customer not updated");
        }

        public async Task<CustomerDTO> DeleteCustomer(Guid id)
        {
            var customer =
                await _customerRepository.GetById(id)
                ?? throw new KeyNotFoundException("Customer not found.");
            await _customerRepository.Delete(id);
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
