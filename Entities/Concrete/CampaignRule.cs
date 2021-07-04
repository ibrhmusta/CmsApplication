using Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete
{
    public partial class CampaignRule : IEntity
    {
        public int Id { get; set; }
        public int CampaignRuleTypeId { get; set; }
        public string Name { get; set; }

    }
}
