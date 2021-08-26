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
        IDataResult<CampaignDetailDto> GetCampaignDetails(int campaignId);
        IResult Add(CampaignDtoForAdd campaignDetailDto);
        IResult Delete(Campaign campaign);
        IResult Update(Campaign campaign);
    }
}
