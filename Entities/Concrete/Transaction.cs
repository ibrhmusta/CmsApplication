using Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete
{
    public partial class Transaction : IEntity
    {
  
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ChannelId { get; set; }
        public int CustomerId { get; set; }
        public int PaymentTypeId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
