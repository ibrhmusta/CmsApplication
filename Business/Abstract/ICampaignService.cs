using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICampaignService
    {
        IDataResult<List<Campaign>> GetAll();
        IDataResult<List<CampaignDetailDto>> GetAllCampaignDetails();
        IResult Add(Campaign campaign);
        IResult Delete(Campaign campaign);
        IResult Update(Campaign campaign);
    }
}
