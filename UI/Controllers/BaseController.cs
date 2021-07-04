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
    public class BaseController<TViewModel> : Controller
    {
        public IRestResponse Post(TViewModel viewModel, RestClient client)
        {
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer" + " " + Constants.token);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(viewModel);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);           
            return response;
        }
        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "swal('" + notificationType.ToString().ToUpper() + "', '" + message + "','" + notificationType + "')" + "";
            TempData["notification"] = msg;
        }
    }
}
 