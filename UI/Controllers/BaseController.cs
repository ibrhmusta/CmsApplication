using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Commons;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        //public IRestResponse Post(TViewModel viewModel, RestClient client, string token)
        //{
        //    client.Timeout = -1;
        //    var request = new RestRequest(Method.POST);

        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        request.AddHeader("Authorization", "Bearer" + " " + token);
        //    }

        //    request.AddHeader("Content-Type", "application/json");
        //    var body = JsonConvert.SerializeObject(viewModel);
        //    request.AddParameter("application/json", body, ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //    return response;
        //}
        public async Task<object> Alert(string message, NotificationType notificationType)
        {
            var msg = "swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "";
            return TempData["notification"] = msg;
        }
    }
}
