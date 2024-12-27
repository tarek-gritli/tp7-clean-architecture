using Microsoft.EntityFrameworkCore;
using tp7.Domain.Entities;
using tp7.Domain.RepositoryInterfaces;

namespace tp7.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext context)
            : base(context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Movie>> GetFavoriteMovies(Guid customerId)
        {
            var customer =
                await _db
                    .Customers.Include(c => c.Movies)
                    .FirstOrDefaultAsync(c => c.Id == customerId)
                ?? throw new KeyNotFoundException("Customer not found.");
            return customer.Movies;
        }
    }
}
