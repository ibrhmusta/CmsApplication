using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICampaignHourService
    {
        IDataResult<List<CampaignHour>> GetAll();
        IResult Add(CampaignHour campaignHour);
        IResult Delete(CampaignHour campaignHour);
        IResult Update(CampaignHour campaignHour);
    }

}
