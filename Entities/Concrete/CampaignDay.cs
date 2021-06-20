using Core.Entities;
using Entities.Enums.CampaignDay;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CampaignDay : IEntity
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public Day DayofWeek { get; set; }
    }
}
