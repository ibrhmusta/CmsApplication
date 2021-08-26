using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignsController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpPost("add")]
        public IActionResult Add(CampaignDtoForAdd campaignDetailDto)
        {
            var result = _campaignService.Add(campaignDetailDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Campaign campaign)
        {
            var result = _campaignService.Delete(campaign);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Campaign campaign)
        {
            var result = _campaignService.Update(campaign);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _campaignService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet("getallcampaigndetails")]
        public IActionResult GetAllCampaignDetails()
        {
            var result = _campaignService.GetAllCampaignDetails();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet("getcampaigndetails")]
        public IActionResult GetCampaignDetails(int campaignId)
        {
            var result = _campaignService.GetCampaignDetails(campaignId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }
    }
}
