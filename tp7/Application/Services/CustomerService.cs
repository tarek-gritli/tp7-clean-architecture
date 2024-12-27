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
            var newCustomer = _mapper.Map<Customer>(customer);

            await _customerRepository.Add(newCustomer);

            return _mapper.Map<CustomerDTO>(newCustomer);
        }

        public async Task<IEnumerable<MovieDTO>> GetFavoriteMovies(Guid customerId)
        {
            var favoriteMovies = await _customerRepository.GetFavoriteMovies(customerId);
            return _mapper.Map<IEnumerable<MovieDTO>>(favoriteMovies);
        }

        public async Task<IEnumerable<MovieReviewDTO>> GetMovieReviews(Guid customerId)
        {
            var movieReviews = await _customerRepository.GetMovieReviews(customerId);
            return _mapper.Map<IEnumerable<MovieReviewDTO>>(movieReviews);
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

            _mapper.Map(customer, customerToUpdate);

            await _customerRepository.Update(customerToUpdate);

            return _mapper.Map<CustomerDTO>(customerToUpdate);
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
