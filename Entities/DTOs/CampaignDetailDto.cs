using Entities.Abstract;
using Entities.Concrete;
using Entities.Enums.CampaignDay;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CampaignDetailDto : IDto
    {
        public string CompanyName { get; set; }
        public Campaign Campaign { get; set; }
        public string Type { get; set; }
        public Day Day { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
    }
}
