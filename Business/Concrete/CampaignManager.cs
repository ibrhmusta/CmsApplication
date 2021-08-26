using Business.Abstract;
using Business.Constants;
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
        private readonly ICampaignRuleDal _campaignRuleDal;
        private readonly ICampaignRewardDal _campaignRewardDal;
        private readonly ICampaignDayDal _campaignDayDal;
        private readonly ICampaignHourDal _campaignHourDal;
        private readonly ICampaignRewardService _campaignRewardService;
        private readonly ICampaignRuleService _campaignRuleService;

        public CampaignManager(ICampaignDal campaignDal, ICampaignRuleDal campaignRuleDal,
            ICampaignRewardDal campaignRewardDal, ICampaignDayDal campaignDayDal, ICampaignHourDal campaignHourDal,
            ICampaignRewardService campaignRewardService, ICampaignRuleService campaignRuleService)
        {
            _campaignDal = campaignDal;
            _campaignRuleDal = campaignRuleDal;
            _campaignRewardDal = campaignRewardDal;
            _campaignDayDal = campaignDayDal;
            _campaignHourDal = campaignHourDal;
            _campaignRewardService = campaignRewardService;
            _campaignRuleService = campaignRuleService;
        }

        public IResult Add(CampaignDtoForAdd campaignDetailDto)
        {
            campaignDetailDto.CampaignReward.CampaignRewardTypeId = campaignDetailDto.CampaignRewardTypeId;
            campaignDetailDto.CampaignRule.CampaignRuleTypeId = campaignDetailDto.CampaignRuleTypeId;
            campaignDetailDto.Campaign.CompanyId = campaignDetailDto.CompanyId;
            campaignDetailDto.Campaign.TypeId = campaignDetailDto.CampaignTypeId;

            campaignDetailDto.CampaignRule.CreatedDate = System.DateTime.Now;
            campaignDetailDto.CampaignRule.ModifiedDate = System.DateTime.Now;
            campaignDetailDto.CampaignRule.IsActive = true;
            campaignDetailDto.CampaignRule.IsDeleted = false;

            _campaignRuleDal.Add(campaignDetailDto.CampaignRule);

            campaignDetailDto.CampaignReward.CreatedDate = System.DateTime.Now;
            campaignDetailDto.CampaignReward.ModifiedDate = System.DateTime.Now;
            campaignDetailDto.CampaignReward.IsActive = true;
            campaignDetailDto.CampaignReward.IsDeleted = false;

            _campaignRewardDal.Add(campaignDetailDto.CampaignReward);

            campaignDetailDto.Campaign.CampaignRuleId = campaignDetailDto.CampaignRule.Id;
            campaignDetailDto.Campaign.CampaignRewardId = campaignDetailDto.CampaignReward.Id;

            campaignDetailDto.Campaign.CreatedDate = System.DateTime.Now;
            campaignDetailDto.Campaign.ModifiedDate = System.DateTime.Now;
            campaignDetailDto.Campaign.IsActive = true;
            campaignDetailDto.Campaign.IsDeleted = false;

            _campaignDal.Add(campaignDetailDto.Campaign);

            campaignDetailDto.CampaignDay.CampaignId = campaignDetailDto.Campaign.Id;
            campaignDetailDto.CampaignHour.CampaignId = campaignDetailDto.Campaign.Id;

            _campaignDayDal.Add(campaignDetailDto.CampaignDay);
            _campaignHourDal.Add(campaignDetailDto.CampaignHour);
            return new SuccessResult(SuccessMessages.CAMPAIGN_ADDED);
        }

        public IResult Delete(Campaign campaign)
        {
            var deletedCampaign = GetCampaignDetails(campaign.Id).Data;

            _campaignDayDal.Delete(deletedCampaign.CampaignDay);
            _campaignHourDal.Delete(deletedCampaign.CampaignHour);

            deletedCampaign.Campaign.IsActive = false;
            deletedCampaign.Campaign.IsDeleted = true;
            deletedCampaign.Campaign.ModifiedDate = System.DateTime.Now;

            _campaignDal.Update(deletedCampaign.Campaign);

            _campaignRewardService.Delete(deletedCampaign.CampaignReward);
            _campaignRuleService.Delete(deletedCampaign.CampaignRule);

            return new SuccessResult(SuccessMessages.CAMPAIGN_DELETED);
        }

        public IDataResult<List<Campaign>> GetAll()
        {
            var result = _campaignDal.GetAll();
            return new SuccessDataResult<List<Campaign>>(result, SuccessMessages.CAMPAIGNS_LISTED);
        }

        public IDataResult<List<CampaignDetailDto>> GetAllCampaignDetails()
        {
            var result = _campaignDal.GetAllCampaignDetails();
            return new SuccessDataResult<List<CampaignDetailDto>>(result, SuccessMessages.CAMPAIGN_DETAILS_LISTED);
        }

        public IDataResult<CampaignDetailDto> GetCampaignDetails(int campaignId)
        {
            var result = _campaignDal.GetAllCampaignDetails(c => c.Id == campaignId).FirstOrDefault();
            return new SuccessDataResult<CampaignDetailDto>(result, SuccessMessages.CAMPAIGN_DETAILS_LISTED);
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
