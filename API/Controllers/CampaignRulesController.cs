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
    public class CampaignRulesController : ControllerBase
    {
        private readonly ICampaignRuleService _campaignRuleService;

        public CampaignRulesController(ICampaignRuleService campaignRuleService)
        {
            _campaignRuleService = campaignRuleService;
        }

        [HttpPost("add")]
        public IActionResult Add(CampaignRule campaignRule)
        {
            var result = _campaignRuleService.Add(campaignRule);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CampaignRule campaignRule)
        {
            var result = _campaignRuleService.Delete(campaignRule);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CampaignRule campaignRule)
        {
            var result = _campaignRuleService.Update(campaignRule);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _campaignRuleService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
