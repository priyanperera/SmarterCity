using Application.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CustomerDto customer)
        {
            await customerService.CreateCustomer(customer);

            return new OkResult();
        }

        [HttpGet]
        public ActionResult<IList<CustomerDto>> Get()
        {
            var results = customerService.GetAllCustomers();

            return new ActionResult<IList<CustomerDto>>(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var result = await customerService.GetCustomer(id);

            return new ActionResult<CustomerDto>(result);
        }
    }
}
