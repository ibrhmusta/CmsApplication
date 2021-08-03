using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignRewardsController : ControllerBase
    {
        private readonly ICampaignRewardService _campaignRewardService;

        public CampaignRewardsController(ICampaignRewardService campaignRewardService)
        {
            _campaignRewardService = campaignRewardService;
        }

        [HttpPost("add")]
        public IActionResult Add(CampaignReward campaignReward)
        {
            var result = _campaignRewardService.Add(campaignReward);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CampaignReward campaignReward)
        {
            var result = _campaignRewardService.Delete(campaignReward);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CampaignReward campaignReward)
        {
            var result = _campaignRewardService.Update(campaignReward);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _campaignRewardService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
