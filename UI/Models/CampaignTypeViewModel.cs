using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models.Abstract;

namespace UI.Models
{
    public class CampaignTypeViewModel : IModel
    {
        public List<CampaignType> CampaignTypes;
    }
}
