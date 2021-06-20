using Core.Utilities.Results;
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
    public class CompaniesController : BaseController<CompanyViewModel>
    {
        [HttpGet]
        public IActionResult Add()
        {           
            return View();
        }
        [HttpPost]
        public IActionResult Add(CompanyViewModel companViewModel)
        {
            var client = new RestClient(Constants.baseUrl + "Companies/add");
            var response = Post(companViewModel, client);
            //var result = JsonConvert.DeserializeObject<IResult>(response.Content);
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
