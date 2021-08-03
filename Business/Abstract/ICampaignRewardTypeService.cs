using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICampaignRewardTypeService
    {
        IDataResult<List<CampaignRewardType>> GetAll();
        IResult Add(CampaignRewardType campaignRewardType);
        IResult Delete(CampaignRewardType campaignRewardType);
        IResult Update(CampaignRewardType campaignRewardType);
    }
}
