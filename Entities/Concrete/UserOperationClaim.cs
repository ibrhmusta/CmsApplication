using Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete
{
    public partial class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
