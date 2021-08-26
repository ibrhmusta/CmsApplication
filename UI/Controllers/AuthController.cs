using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using UI.Commons;
using UI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace UI.Controllers
{

    public class AuthController : BaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            var result = RestsharpHelper.Post<DataResult<AccessToken>>("Auth/login", userLoginModel, null);

            //RestClient client = new RestClient(Constants.baseUrl + "Auth/login");
            //IRestResponse response = Post(userLoginModel, client, null);
            //var result = JsonConvert.DeserializeObject<DataResult<AccessToken>>(response.Content);

            if (result == null || result.Data == null)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            JwtSecurityToken DecodedToken = new JwtSecurityToken(jwtEncodedString: result.Data.Token);
            string Role = DecodedToken.Claims.First(c => c.Type.Contains("role")).Value;

            UserInfo(userLoginModel.UserName);

            HttpContext.Session.SetString(Constants.SessionRole, Role);
            HttpContext.Session.SetString(Constants.SessionToken, result.Data.Token);

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Role,Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


            if (!result.Success)
            {
                await Alert(result.Message, NotificationType.error);
                return View();
            }
            await Alert(result.Message, NotificationType.success);
            return RedirectToAction("Admin", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Auth");
        }

        private void UserInfo(string userName)
        {
            var result = RestsharpHelper.Get<UserDetailDto>("users/getuserdetails?userName=" + userName);

            //var client = new RestClient("https://localhost:5001/api/users/getuserdetails?userName=" + userName)
            //{
            //    Timeout = -1
            //};
            //var request = new RestRequest(Method.GET);
            //IRestResponse response = client.Execute(request);
            //var dataResult = JsonConvert.DeserializeObject<UserDetailDto>(response.Content);


            HttpContext.Session.SetString(Constants.SessionName, result.FirstName);
            HttpContext.Session.SetString(Constants.SessionSurname, result.LastName);
            HttpContext.Session.SetString(Constants.SessionCompany, result.CompanyName);
            HttpContext.Session.SetInt32(Constants.SessionCompanyId, result.CompanyId);
        }
    }
}
