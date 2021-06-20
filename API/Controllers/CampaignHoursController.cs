using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignHoursController : ControllerBase
    {
        private readonly ICampaignHourService _campaignHourService;

        public CampaignHoursController(ICampaignHourService campaignHourService)
        {
            _campaignHourService = campaignHourService;
        }

        [HttpPost("add")]
        public IActionResult Add(CampaignHour campaignHour)
        {
            var result = _campaignHourService.Add(campaignHour);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CampaignHour campaignHour)
        {
            var result = _campaignHourService.Delete(campaignHour);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CampaignHour campaignHour)
        {
            var result = _campaignHourService.Update(campaignHour);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _campaignHourService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
