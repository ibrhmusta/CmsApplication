using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
    }
}
