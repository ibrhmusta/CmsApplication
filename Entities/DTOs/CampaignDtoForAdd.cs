using Entities.Abstract;
using Entities.Concrete;
using Entities.Enums.CampaignDay;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CampaignDtoForAdd : IDto
    {
        public Campaign Campaign { get; set; }
        public CampaignRule CampaignRule { get; set; }
        public CampaignReward CampaignReward { get; set; }
        public CampaignDay CampaignDay { get; set; }
        public CampaignHour CampaignHour { get; set; }
        public int CompanyId { get; set; }
        public int CampaignTypeId { get; set; }
        public int CampaignRuleTypeId { get; set; }
        public int CampaignRewardTypeId { get; set; }
    }
}
