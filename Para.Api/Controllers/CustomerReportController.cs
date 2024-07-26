using Microsoft.AspNetCore.Mvc;
using Para.Data.DapperRepository;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReportController(CustomerRepository customerRepository) : ControllerBase
    {
        [HttpGet("{customerId:long}")]
        public async Task<IActionResult> GetCustomerWithDetails(long customerId)
        {
            var customer = await customerRepository.GetCustomerWithDetailsAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
