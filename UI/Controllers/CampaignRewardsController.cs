using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models.CampaignRewards;

namespace UI.Controllers
{
    public class CampaignRewardsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CampaignRewardModel campaignRewardModel)
        {
            return View();
        }
    }
}
