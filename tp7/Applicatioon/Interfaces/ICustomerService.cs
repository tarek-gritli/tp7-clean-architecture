using tp7.Application.DTOs;
using tp7.Domain.Entities;

namespace tp7.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> CreateCustomer(CustomerDTO customer);
        Task<Customer> UpdateCustomer(CustomerDTO customer);
        Task DeleteCustomer(Guid id);
    }
}
