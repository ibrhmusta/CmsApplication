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
    public class CampaignRuleTypesController : ControllerBase
    {
        private readonly ICampaignRuleTypeService _campaignRuleTypeService;

        public CampaignRuleTypesController(ICampaignRuleTypeService campaignRuleTypeService)
        {
            _campaignRuleTypeService = campaignRuleTypeService;
        }

        [HttpPost("add")]
        public IActionResult Add(CampaignRuleType campaignRuleType)
        {
            var result = _campaignRuleTypeService.Add(campaignRuleType);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CampaignRuleType campaignRuleType)
        {
            var result = _campaignRuleTypeService.Delete(campaignRuleType);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CampaignRuleType campaignRuleType)
        {
            var result = _campaignRuleTypeService.Update(campaignRuleType);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _campaignRuleTypeService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
