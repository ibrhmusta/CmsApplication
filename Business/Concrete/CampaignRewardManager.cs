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
    public class CampaignRewardManager : ICampaignRewardService
    {
        private readonly ICapmaignRewardDal _campaignRewardDal;

        public CampaignRewardManager(ICapmaignRewardDal campaignRewardDal)
        {
            _campaignRewardDal = campaignRewardDal;
        }

        public IResult Add(CampaignReward campaignReward)
        {
            campaignReward.CreatedDate = System.DateTime.Now;
            campaignReward.ModifiedDate = System.DateTime.Now;
            campaignReward.IsActive = true;
            campaignReward.IsDeleted = false;
            _campaignRewardDal.Add(campaignReward);
            return new SuccessResult(SuccessMessages.CAMPAIGN_REWARD_ADDED);
        }

        public IResult Delete(CampaignReward campaignReward)
        {
            campaignReward.IsActive = false;
            campaignReward.IsDeleted = true;
            _campaignRewardDal.Update(campaignReward);
            return new SuccessResult(SuccessMessages.CAMPAIGN_REWARD_DELETED);
        }

        public IDataResult<List<CampaignReward>> GetAll()
        {
            var result = _campaignRewardDal.GetAll(c => c.IsActive = true);
            return new SuccessDataResult<List<CampaignReward>>(result, SuccessMessages.CAMPAIGN_REWARDS_LISTED);
        }

        public IResult Update(CampaignReward campaignReward)
        {
            campaignReward.ModifiedDate = System.DateTime.Now;
            _campaignRewardDal.Update(campaignReward);
            return new SuccessResult(SuccessMessages.CAMPAIGN_REWARD_UPDATED);
        }
    }
}
