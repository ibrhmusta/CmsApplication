using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICampaignRuleTypeService
    {
        IDataResult<List<CampaignRuleType>> GetAll();
        IResult Add(CampaignRuleType campaignRuleType);
        IResult Delete(CampaignRuleType campaignRuleType);
        IResult Update(CampaignRuleType campaignRuleType);
    }
}
