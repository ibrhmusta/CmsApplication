using Entities.Abstract;
using Entities.Enums.CampaignDay;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete
{
    public partial class CampaignDay : IEntity
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public Day DayofWeek { get; set; }

    }
}
