using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignDaysController : ControllerBase
    {
        private readonly ICampaignDayService _campaignDayService;

        public CampaignDaysController(ICampaignDayService campaignDayService)
        {
            _campaignDayService = campaignDayService;
        }

        [HttpPost("add")]
        public IActionResult Add(CampaignDay campaignDay)
        {
            var result = _campaignDayService.Add(campaignDay);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CampaignDay campaignDay)
        {
            var result = _campaignDayService.Delete(campaignDay);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CampaignDay campaignDay)
        {
            var result = _campaignDayService.Update(campaignDay);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _campaignDayService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
