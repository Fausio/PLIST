using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PLIST.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PLIST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        List<obj> _list;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _list = new List<obj>();

            for (int i = 0; i < 100; i++)
            {
                _list.Add(new obj() { id = i, name = "nome:" + i });
            }

        }

        public async Task<IActionResult> Index(int PageNumber = 1)
        {

            var data = await pageList<obj>.CreateAsync(_list.AsQueryable(), PageNumber, 5);
       
            return View(data);
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
