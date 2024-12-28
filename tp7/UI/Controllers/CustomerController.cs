using Microsoft.AspNetCore.Mvc;
using tp7.Application.DTOs;
using tp7.Application.Interfaces;

namespace tp7.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: /api/customer/{customerId}/movies
        [HttpGet("{customerId}/movies")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetFavoriteMovies(Guid customerId)
        {
            try
            {
                var favoriteMovies = await _customerService.GetFavoriteMovies(customerId);
                return Ok(favoriteMovies);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: /api/customer/{customerId}/reviews
        [HttpGet("{customerId}/reviews")]
        public async Task<ActionResult<IEnumerable<MovieReviewDTO>>> GetMovieReviews(
            Guid customerId
        )
        {
            try
            {
                var movieReviews = await _customerService.GetMovieReviews(customerId);
                return Ok(movieReviews);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/customer/{id}
        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(Guid customerId)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(customerId);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/customer
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                await _customerService.CreateCustomer(customerDTO);
                return CreatedAtAction(
                    nameof(GetCustomerById),
                    new { CustomerId = customerDTO.Id },
                    customerDTO
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/customer/{customerId}
        [HttpPut("{customerId}")]
        public async Task<ActionResult> UpdateCustomer(
            Guid customerId,
            [FromBody] CustomerDTO customerDTO
        )
        {
            try
            {
                if (customerId != customerDTO.Id)
                {
                    return BadRequest("Customer ID mismatch.");
                }

                await _customerService.UpdateCustomer(customerDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/customer/{customerId}
        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteCustomer(Guid customerId)
        {
            try
            {
                await _customerService.DeleteCustomer(customerId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
