
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models.Abstract;

namespace UI.Models.Campaigns
{
    public class CampaignAddModel:IModel
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
