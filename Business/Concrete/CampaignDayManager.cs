using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CampaignDayManager : ICampaignDayService
    {
        private readonly ICampaignDayDal _campaignDayDal;

        public CampaignDayManager(ICampaignDayDal campaignDayDal)
        {
            _campaignDayDal = campaignDayDal;
        }

        public IResult Add(CampaignDay campaignDay)
        {
            _campaignDayDal.Add(campaignDay);
            return new SuccessResult(SuccessMessages.CAMPAIGN_DAY_ADDED);
        }

        public IResult Delete(CampaignDay campaignDay)
        {
            _campaignDayDal.Delete(campaignDay);
            return new SuccessResult(SuccessMessages.CAMPAIGN_DAY_DELETED);
        }

        public IDataResult<List<CampaignDay>> GetAll()
        {
            var result = _campaignDayDal.GetAll();
            return new SuccessDataResult<List<CampaignDay>>(result, SuccessMessages.CAMPAIGN_DAYS_LISTED);
        }

        public IResult Update(CampaignDay campaignDay)
        {
            _campaignDayDal.Update(campaignDay);
            return new SuccessResult(SuccessMessages.CAMPAIGN_DAY_UPDATED);
        }
    }
}
