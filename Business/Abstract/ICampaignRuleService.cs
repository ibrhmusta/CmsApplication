using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICampaignRuleService
    {
        IDataResult<List<CampaignRule>> GetAll();
        IResult Add(CampaignRule campaignRule);
        IResult Delete(CampaignRule campaignRule);
        IResult Update(CampaignRule campaignRule);
    }
}
