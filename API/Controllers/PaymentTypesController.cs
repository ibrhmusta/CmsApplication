using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaymentTypesController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypesController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }
    }
}
