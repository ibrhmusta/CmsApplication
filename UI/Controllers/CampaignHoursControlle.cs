using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class CampaignHoursControlle : Controller
    {
        [HttpPost]
        public IActionResult Add()
        {
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
