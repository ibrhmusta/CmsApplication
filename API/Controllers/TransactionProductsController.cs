using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TransactionProductsController : ControllerBase
    {
        private readonly ITransactionProductService _transactionProductService;

        public TransactionProductsController(ITransactionProductService transactionProductService)
        {
            _transactionProductService = transactionProductService;
        }
    }
}
