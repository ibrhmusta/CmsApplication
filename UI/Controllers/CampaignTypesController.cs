using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Commons;
using UI.Models;

namespace UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CampaignTypesController : Controller
    {
        [HttpPost]
        public IActionResult Add()
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
            var result = RestsharpHelper.Get<List<CampaignType>>("CampaignTypes/getall");

            //var client = new RestClient("https://localhost:5001/api/CampaignTypes/getall");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = client.Execute(request);
            //var dataResult = JsonConvert.DeserializeObject<List<CampaignType>>(response.Content);

            CampaignTypeViewModel model = new CampaignTypeViewModel() { CampaignTypes = result };
            return View(model);
        }
    }
}
