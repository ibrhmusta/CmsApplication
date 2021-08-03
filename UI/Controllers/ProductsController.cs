using AutoMapper;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            var client = new RestClient("https://localhost:5001/api/Products/getallproductdetails");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);         
            var dataResult = JsonConvert.DeserializeObject<List<ProductDetailDto>>(response.Content);
            ProductDetailViewModel model = new ProductDetailViewModel() { ProductDetails = dataResult };
            return View(model);
        }
    }
}
