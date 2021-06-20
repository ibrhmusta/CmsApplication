using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CampaignManager : ICampaignService
    {
        private readonly ICampaignDal _campaignDal;

        public CampaignManager(ICampaignDal campaignDal)
        {
            _campaignDal = campaignDal;
        }

        public IResult Add(Campaign campaign)
        {
            IResult result = BusinessRules.Run(IsCampaignExist(campaign.Name));
            campaign.CreatedDate = System.DateTime.Now;
            campaign.ModifiedDate = System.DateTime.Now;
            campaign.IsActive = true;
            campaign.IsDeleted = false;
            if (!result.Success)
            {
                return result;
            }
            _campaignDal.Add(campaign);
            return new SuccessResult(SuccessMessages.CAMPAIGN_ADDED);
        }

        public IResult Delete(Campaign campaign)
        {
            campaign.IsActive = false;
            campaign.IsDeleted = true;
            campaign.ModifiedDate = System.DateTime.Now;
            _campaignDal.Update(campaign);
            return new SuccessResult(SuccessMessages.CAMPAIGN_DELETED);
        }

        public IDataResult<List<Campaign>> GetAll()
        {
            var result = _campaignDal.GetAll();
            return new SuccessDataResult<List<Campaign>>(result,SuccessMessages.CAMPAIGNS_LISTED);
        }

        public IDataResult<List<CampaignDetailDto>> GetAllCampaignDetails()
        {
            var result = _campaignDal.GetAllCampaignDetails();
            return new SuccessDataResult<List<CampaignDetailDto>>(result, SuccessMessages.CAMPAIGN_DETAILS_LISTED);
        }

        public IResult Update(Campaign campaign)
        {
            campaign.ModifiedDate = System.DateTime.Now;
            _campaignDal.Update(campaign);
            return new SuccessResult(SuccessMessages.CAMPAIGN_UPDATED);
        }

        private IResult IsCampaignExist(string campaignName)
        {
            var result = _campaignDal.GetAll(campaign => campaign.Name == campaignName).Any();
            if (result)
            {
                return new ErrorResult(ErrorMessages.CAMPAIGN_ALREADY_EXIST);
            }
            return new SuccessResult();
        }
    }
}
