using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CampaignHourManager : ICampaignHourService
    {
        private readonly ICampaignHourDal _campaignHourDal;

        public CampaignHourManager(ICampaignHourDal campaignHourDal)
        {
            _campaignHourDal = campaignHourDal;
        }

        public IResult Add(CampaignHour campaignHour)
        {
            _campaignHourDal.Add(campaignHour);
            return new SuccessResult(SuccessMessages.CAMPAIGN_HOUR_ADDED);
        }

        public IResult Delete(CampaignHour campaignHour)
        {
            _campaignHourDal.Delete(campaignHour);
            return new SuccessResult(SuccessMessages.CAMPAIGN_HOUR_DELETED);
        }

        public IDataResult<List<CampaignHour>> GetAll()
        {
            var result = _campaignHourDal.GetAll();
            return new SuccessDataResult<List<CampaignHour>>(result,SuccessMessages.CAMPAIGN_HOURS_LISTED);
        }

        public IResult Update(CampaignHour campaignHour)
        {
            _campaignHourDal.Update(campaignHour);
            return new SuccessResult(SuccessMessages.CAMPAIGN_HOUR_UPDATED);
        }
    }
}
