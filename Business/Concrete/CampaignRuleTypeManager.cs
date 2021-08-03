using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CampaignRuleTypeManager : ICampaignRuleTypeService
    {
        private readonly ICapmaignRuleTypeDal _campaignRuleTypeDal;

        public CampaignRuleTypeManager(ICapmaignRuleTypeDal campaignRuleTypeDal)
        {
            _campaignRuleTypeDal = campaignRuleTypeDal;
        }

        public IResult Add(CampaignRuleType campaignRuleType)
        {
            _campaignRuleTypeDal.Add(campaignRuleType);
            return new SuccessResult(SuccessMessages.CAMPAIGN_RULE_TYPE_ADDED);
        }

        public IResult Delete(CampaignRuleType campaignRuleType)
        {
            _campaignRuleTypeDal.Delete(campaignRuleType);
            return new SuccessResult(SuccessMessages.CAMPAIGN_RULE_DELETED);
        }

        public IDataResult<List<CampaignRuleType>> GetAll()
        {
            var result = _campaignRuleTypeDal.GetAll();
            return new SuccessDataResult<List<CampaignRuleType>>(result, SuccessMessages.CAMPAIGN_RULE_TYPES_LISTED);
        }

        public IResult Update(CampaignRuleType campaignRuleType)
        {
            _campaignRuleTypeDal.Update(campaignRuleType);
            return new SuccessResult(SuccessMessages.CAMPAIGN_RULE_TYPE_UPDATED);
        }
    }
}
