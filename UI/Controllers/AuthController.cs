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

    public class AuthController : BaseController<UserLoginModel>
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            const string SessionName = "_Name";
            const string SessionSurname = "_Surname";
            const string SessionRole = "_Role";
            const string SessionToken = "_Token";
            const string SessionCompany = "_Company";

            RestClient client = new RestClient(Constants.baseUrl + "Auth/login");

            IRestResponse response = Post(userLoginModel, client, null);
            var result = JsonConvert.DeserializeObject<DataResult<AccessToken>>(response.Content);

            if (result.Data == null)
            {
                return View();
            }

            JwtSecurityToken DecodedToken = new JwtSecurityToken(jwtEncodedString: result.Data.Token);
            string Role = DecodedToken.Claims.First(c => c.Type.Contains("role")).Value;

            UserInfo(userLoginModel.UserName);

            HttpContext.Session.SetString(SessionRole, Role);
            HttpContext.Session.SetString(SessionToken, result.Data.Token);

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Role,Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);
            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


            if (!result.Success)
            {             
                return View();
            }
            return RedirectToAction("Admin", "Home");
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            var logOut = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Auth");
        }

        private void UserInfo(string userName)
        {
            var client = new RestClient("https://localhost:5001/api/users/getuserdetails?userName=" + userName);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var dataResult = JsonConvert.DeserializeObject<UserDetailDto>(response.Content);
;
            
            HttpContext.Session.SetString("_Name", dataResult.FirstName);
            HttpContext.Session.SetString("_Surname", dataResult.LastName);
            HttpContext.Session.SetString("_Company", dataResult.CompanyName);
        }
    }
}
