using Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete
{
    public partial class CampaignHour : IEntity
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public DateTime StartedHour { get; set; }
        public DateTime EndedHour { get; set; }
    }
}
