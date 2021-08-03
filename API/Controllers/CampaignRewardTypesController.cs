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
    public class CampaignRewardTypesController : ControllerBase
    {
        private readonly ICampaignRewardTypeService _campaignRewardTypeService;

        public CampaignRewardTypesController(ICampaignRewardTypeService campaignRewardTypeService)
        {
            _campaignRewardTypeService = campaignRewardTypeService;
        }

        [HttpPost("add")]
        public IActionResult Add(CampaignRewardType campaignRewardType)
        {
            var result = _campaignRewardTypeService.Add(campaignRewardType);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CampaignRewardType campaignRewardType)
        {
            var result = _campaignRewardTypeService.Delete(campaignRewardType);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CampaignRewardType campaignRewardType)
        {
            var result = _campaignRewardTypeService.Update(campaignRewardType);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _campaignRewardTypeService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
