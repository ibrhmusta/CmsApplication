using AutoMapper;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public  class ProductController : Controller
    {
        private readonly IMapper _mapper;
        
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Product()
        {
            //nullcheck eklenecek
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync("https://localhost:5001/api/Products/getallproductdetails").Result;
            var dataResult = JsonConvert.DeserializeObject<List<ProductDetailDto>>(httpResult.Content.ReadAsStringAsync().Result);
            ProductDetailViewModel model = new ProductDetailViewModel() { ProductDetails = dataResult };
            return View(model);
        }
    }
}
