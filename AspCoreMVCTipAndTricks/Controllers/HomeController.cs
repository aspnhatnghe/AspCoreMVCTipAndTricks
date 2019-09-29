using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCoreMVCTipAndTricks.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AspCoreMVCTipAndTricks.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult ReadConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("myappsettings.json");
            var config = builder.Build();

            //Đọc giá trị
            ViewBag.Message = config["Message"];
            ViewBag.Config1 = config["MyConfigs:Config1"];
            ViewBag.Config2 = config["MyConfigs:Config2"];
            ViewBag.Config3 = config["MyConfigs:Config3"];
            ViewBag.ConnectionString = config.GetConnectionString("MyShop");

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
