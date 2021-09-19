using Dept_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Dept_Test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(LatestResult search)
        {
            bool validated = search.validateCityName();
            ViewData["Title"] = search.cityName + " Results";
            if (validated)
            {
                if (await search.getResults())
                {
                    return View("Search",search);
                }
            }
            return View("Error",search);
        }       
    }
}
