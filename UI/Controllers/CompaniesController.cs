using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Commons;
using UI.Models;

namespace UI.Controllers
{
    [Authorize(Roles ="admin")]
    public class CompaniesController : BaseController
    {
        [HttpGet]
        public IActionResult Add()
        {           
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Add(CompanyViewModel companyViewModel)
        {
            var result = RestsharpHelper.Post<Result>("Companies/add", companyViewModel,HttpContext.Session.GetString(Constants.SessionToken));

            //var client = new RestClient(Constants.baseUrl + "Companies/add");
            //var response = Post(companyViewModel, client, HttpContext.Session.GetString("_Token"));
            //var result = JsonConvert.DeserializeObject<Result>(response.Content);

            if (!result.Success) 
            {
                await Alert(result.Message, NotificationType.error);
                return View();
            }
            await Alert(result.Message, NotificationType.success);
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
            return View();
        }
    }
}
