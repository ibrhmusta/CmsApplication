using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models.CampaignRewardTypes;

namespace UI.Controllers
{
    public class CampaignRewardTypesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CampaignRewardTypeModel campaignRewardTypeModel)
        {
            return View();
        }
    }
}
