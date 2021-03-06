using Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete
{
    public partial class CampaignType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }
}
