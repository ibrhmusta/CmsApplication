using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class TransactionDetailDto
    {
        public string Channel { get; set; }
        public string PaymentType { get; set; }
        public Transaction Transaction { get; set; }
        public TransactionProduct TransactionProduct { get; set; }       
        public Product Product { get; set; }
        public Customer Customer  { get; set; }
       
    }
}
