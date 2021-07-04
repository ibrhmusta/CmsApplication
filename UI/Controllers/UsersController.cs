using Core.Utilities.Results;
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
    public class UsersController : BaseController<UserAddModel>
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserAddModel userAddModel)
        {
            var client = new RestClient(Constants.baseUrl + "Auth/register");
            var response = Post(userAddModel, client);
            var result = JsonConvert.DeserializeObject<Result>(response.Content);
            if (!result.Success)
            {
                Alert(result.Message, NotificationType.error);
                return View();
            }
            Alert(result.Message, NotificationType.success);
            return View();
        }
    }
}
