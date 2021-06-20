using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CampaignHour : IEntity
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public DateTime StartedHour { get; set; }
        public DateTime EndedHour{ get; set; }
    }
}
