using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICampaignDayService
    {
        IDataResult<List<CampaignDay>> GetAll();
        IResult Add(CampaignDay campaignDay);
        IResult Delete(CampaignDay campaignDay);
        IResult Update(CampaignDay campaignDay);
    }

}
