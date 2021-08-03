using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICampaignRewardService
    {
        IDataResult<List<CampaignReward>> GetAll();
        IResult Add(CampaignReward campaignReward);
        IResult Delete(CampaignReward campaignReward);
        IResult Update(CampaignReward campaignReward);
    }
}