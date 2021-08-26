using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Commons;
using UI.Models;
using UI.Models.Campaigns;

namespace UI.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class CampaignsController : BaseController
    {

        [HttpGet]
        public IActionResult Add()
        {

            List<CampaignType> typeResult = RestsharpHelper.Get<List<CampaignType>>("CampaignTypes/getall");
            var ruleResult = RestsharpHelper.Get<List<CampaignRuleType>>("CampaignRuleTypes/getall");
            var rewardResult = RestsharpHelper.Get<List<CampaignRewardType>>("CampaignRewardTypes/getall");
            CampaignModel campaignModel = new CampaignModel()
            {
                campaignTypes = typeResult,
                campaignRuleTypes = ruleResult,
                campaignRewardTypes = rewardResult
            };
            return View(campaignModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CampaignModel campaignModel)
        {
            CampaignAddModel campaignAddModel = new CampaignAddModel
            {
                Campaign = campaignModel.Campaign,
                CampaignDay = campaignModel.CampaignDay,
                CampaignHour = campaignModel.CampaignHour,
                CampaignReward = campaignModel.CampaignReward,
                CampaignRule = campaignModel.CampaignRule,
                CompanyId = (int)HttpContext.Session.GetInt32("_CompanyId"),
                CampaignTypeId = campaignModel.CampaignTypeId,
                CampaignRewardTypeId = campaignModel.CampaignRewardTypeId,
                CampaignRuleTypeId = campaignModel.CampaignRuleTypeId
            };

            var result = RestsharpHelper.Post<Result>("Campaigns/add", campaignAddModel, HttpContext.Session.GetString(Constants.SessionToken));

            //var client = new RestClient(Constants.baseUrl + "Campaigns/add");
            //campaignAddModel.CompanyId = (int)HttpContext.Session.GetInt32(Constants.SessionCompanyId);
            //var response = Post(campaignAddModel, client, HttpContext.Session.GetString(Constants.SessionToken));
            //var result = JsonConvert.DeserializeObject<Result>(response.Content);

            if (!result.Success)
            {
                await Alert(result.Message, NotificationType.error);
                return View();
            }
            await Alert(result.Message, NotificationType.success);
            return RedirectToAction("Add", "Campaigns");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedResult = RestsharpHelper.Get<CampaignDetailDto>("Campaigns/getcampaigndetails?campaignId=" + id);
            var result = RestsharpHelper.Post<Result>("Campaigns/delete", deletedResult.Campaign, HttpContext.Session.GetString(Constants.SessionToken));

            if (!result.Success)
            {
                await Alert(result.Message, NotificationType.error);
                return View("List", "Campaigns");
            }
            await Alert(result.Message, NotificationType.success);
            return RedirectToAction("List", "Campaigns");
        }

        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = RestsharpHelper.Get<List<CampaignDetailDto>>("Campaigns/getallcampaigndetails");

            //var client = new RestClient("https://localhost:5001/api/Campaigns/getallcampaigndetails");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = client.Execute(request);
            //var dataResult = JsonConvert.DeserializeObject<List<CampaignDetailDto>>(response.Content);

            CampaignViewModel model = new CampaignViewModel() { CampaignDetails = result };
            return View(model);
        }

        [HttpGet]
        public IActionResult DetailList()
        {
            return View();
        }
    }
}
