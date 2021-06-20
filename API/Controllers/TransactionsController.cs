using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("add")]
        public IActionResult Add(Transaction transaction)
        {
            var result = _transactionService.Add(transaction);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Transaction transaction)
        {
            var result = _transactionService.Delete(transaction);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Transaction transaction)
        {
            var result = _transactionService.Update(transaction);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _transactionService.GetAll();
            if (!result.Success) 
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getalltransactiondetails")]
        public IActionResult GetAllTransactionDetails()
        {
            var result = _transactionService.GetAllTransactionDetails();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
