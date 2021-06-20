using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICampaignDal : IEntityRepository<Campaign>
    {
        List<CampaignDetailDto> GetAllCampaignDetails(Expression<Func<Campaign, bool>> filter = null);
    }

}
