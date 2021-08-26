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
    public class CampaignRuleManager : ICampaignRuleService
    {
        private readonly ICampaignRuleDal _campaignRuleDal;

        public CampaignRuleManager(ICampaignRuleDal campaignRuleDal)
        {
            _campaignRuleDal = campaignRuleDal;
        }

        public IResult Add(CampaignRule campaignRule)
        {
            campaignRule.CreatedDate = System.DateTime.Now;
            campaignRule.ModifiedDate = System.DateTime.Now;
            campaignRule.IsActive = true;
            campaignRule.IsDeleted = false;
            _campaignRuleDal.Add(campaignRule);
            return new SuccessResult(SuccessMessages.CAMPAIGN_RULE_ADDED);
        }

        public IResult Delete(CampaignRule campaignRule)
        {
            campaignRule.IsActive = false;
            campaignRule.IsDeleted = true;
            _campaignRuleDal.Update(campaignRule);
            return new SuccessResult(SuccessMessages.CAMPAIGN_RULE_DELETED);
        }

        public IDataResult<List<CampaignRule>> GetAll()
        {
            var result = _campaignRuleDal.GetAll(c => c.IsActive = true);
            return new SuccessDataResult<List<CampaignRule>>(result, SuccessMessages.CAMPAIGN_RULES_LISTED);
        }

        public IResult Update(CampaignRule campaignRule)
        {
            campaignRule.ModifiedDate = System.DateTime.Now;
            _campaignRuleDal.Update(campaignRule);
            return new SuccessResult(SuccessMessages.CAMPAIGN_RULE_UPDATED);
        }
    }
}
