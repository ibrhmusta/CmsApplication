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
    public class CampaignRewardTypeManager : ICampaignRewardTypeService
    {
        private readonly ICapmaignRewardTypeDal _campaignRewardTypeDal;

        public CampaignRewardTypeManager(ICapmaignRewardTypeDal campaignRewardTypeDal)
        {
            _campaignRewardTypeDal = campaignRewardTypeDal;
        }

        public IResult Add(CampaignRewardType campaignRewardType)
        {
            _campaignRewardTypeDal.Add(campaignRewardType);
            return new SuccessResult(SuccessMessages.CAMPAIGN_REWARD_TYPE_ADDED);
        }

        public IResult Delete(CampaignRewardType campaignRewardType)
        {
            _campaignRewardTypeDal.Delete(campaignRewardType);
            return new SuccessResult(SuccessMessages.CAMPAIGN_REWARD_TYPE_DELETED);
        }

        public IDataResult<List<CampaignRewardType>> GetAll()
        {
            var result = _campaignRewardTypeDal.GetAll();
            return new SuccessDataResult<List<CampaignRewardType>>(result, SuccessMessages.CAMPAIGN_REWARD_TYPES_LISTED);
        }

        public IResult Update(CampaignRewardType campaignRewardType)
        {
            _campaignRewardTypeDal.Update(campaignRewardType);
            return new SuccessResult(SuccessMessages.CAMPAIGN_REWARD_TYPE_UPDATED);
        }
    }
}
