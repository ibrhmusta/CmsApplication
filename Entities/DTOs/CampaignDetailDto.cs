using Entities.Concrete;
using Entities.Enums.CampaignDay;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CampaignDetailDto
    {
        public Campaign Campaign { get; set; }
        public string CampaignRuleType { get; set; }
        public double CampaignRuleValue { get; set; }
        public string CampaignRewardType { get; set; }
        public double CampaignRewardValue { get; set; }
        public string CompanyName { get; set; }
        public string CampaignType { get; set; }
        public CampaignDay CampaignDay { get; set; }
        public CampaignHour CampaignHour { get; set; }
        public CampaignRule CampaignRule { get; set; }
        public CampaignReward CampaignReward { get; set; }
    }
}
