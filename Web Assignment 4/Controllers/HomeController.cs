using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web_Assignment_4.Models;
using Web_Assignment_4.Models.Api;

namespace Web_Assignment_4.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List(string q)
        {
            ApiHelper api = new ApiHelper();
            var list = await api.Get(q,10);
            return View(list);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Chart()
        {
            return View();
        }

        public IActionResult ChartJs(string q)
        {
            return View();
        }

        public async Task<JsonResult> GetChartData(string state)
        {
            ApiHelper api = new ApiHelper();
            var list = await api.Get($"classification.exact:\"Class I\"+AND+state.exact:\"{state}\"&count=report_date");


            return Json(new
            {
                labels = list.Select(c => c.year).Distinct(),
                data = list.GroupBy(c => c.year, (i, y) => y.Sum(c => c.count))
            });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
