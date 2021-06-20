using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignTypesController : ControllerBase
    {
        private readonly ICampaignTypeService _campaignTypeService;

        public CampaignTypesController(ICampaignTypeService campaignTypeService)
        {
            _campaignTypeService = campaignTypeService;
        }

        [HttpPost("add")]
        public IActionResult Add(CampaignType campaignType)
        {
            var result = _campaignTypeService.Add(campaignType);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CampaignType campaignType)
        {
            var result = _campaignTypeService.Delete(campaignType);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CampaignType campaignType)
        {
            var result = _campaignTypeService.Update(campaignType);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _campaignTypeService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
