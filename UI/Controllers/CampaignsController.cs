using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class CampaignsController : BaseController<CampaignViewModel>
    {

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CampaignViewModel campaignViewModel)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var client = new RestClient("https://localhost:5001/api/Campaigns/getallcampaigndetails");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var dataResult = JsonConvert.DeserializeObject<List<CampaignDetailDto>>(response.Content);
            CampaignViewModel model = new CampaignViewModel() { CampaignDetails = dataResult };
            return View(model);
        }

        [HttpGet]
        public IActionResult DetailList()
        {
            return View();
        }
    }
}
