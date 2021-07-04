using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
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
    
    public class AuthController : BaseController<UserLoginModel>
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var client = new RestClient(Constants.baseUrl + "Auth/login");
            var response = Post(userLoginModel, client);
            var result = JsonConvert.DeserializeObject<DataResult<AccessToken>>(response.Content);
            Constants.token = result.Data.Token;
            if (!result.Success) 
            {
                return View(result.Message);
            }
            return RedirectToAction("Admin", "Home");
        }
    }
}
