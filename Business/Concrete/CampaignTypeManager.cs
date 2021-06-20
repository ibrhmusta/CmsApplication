using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CampaignTypeManager : ICampaignTypeService
    {
        private readonly ICampaignTypeDal _campaignTypeDal;

        public CampaignTypeManager(ICampaignTypeDal campaignTypeDal)
        {
            _campaignTypeDal = campaignTypeDal;
        }

        public IResult Add(CampaignType campaignType)
        {
            campaignType.CreatedDate = System.DateTime.Now;
            campaignType.ModifiedDate = System.DateTime.Now;
            campaignType.IsActive = true;
            campaignType.IsDeleted = false;
            _campaignTypeDal.Add(campaignType);
            return new SuccessResult(SuccessMessages.CAMPAIGN_TYPE_ADDED);
        }

        public IResult Delete(CampaignType campaignType)
        {
            campaignType.IsActive = false;
            campaignType.IsDeleted = true;
            campaignType.ModifiedDate = System.DateTime.Now;
            _campaignTypeDal.Update(campaignType);
            return new SuccessResult(SuccessMessages.CAMPAIGN_TYPE_DELETED);
        }

        public IDataResult<List<CampaignType>> GetAll()
        {
            var result = _campaignTypeDal.GetAll();
            return new SuccessDataResult<List<CampaignType>>(result,SuccessMessages.CAMPAIGN_TYPES_LISTED);
        }

        public IResult Update(CampaignType campaignType)
        {
            campaignType.ModifiedDate = System.DateTime.Now;
            _campaignTypeDal.Update(campaignType);
            return new SuccessResult(SuccessMessages.COMPANY_UPDATED);
        }
    }
}
