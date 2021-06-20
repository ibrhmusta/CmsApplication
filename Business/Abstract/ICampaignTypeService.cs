using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICampaignTypeService
    {
        IDataResult<List<CampaignType>> GetAll();
        IResult Add(CampaignType campaignType);
        IResult Delete(CampaignType campaignType);
        IResult Update(CampaignType campaignType);
    }

}
