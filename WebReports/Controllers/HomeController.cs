using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebReports.Models;

namespace WebReports.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PowerBIEmbed()
        {
            IList<PowerBI> pbirpt = new List<PowerBI>();
            pbirpt.Add(new PowerBI() { WorkspaceId = "f3f59d07-2220-4750-9736-e7e619dd19fc", ReportId= "68432287-1e6e-471b-8077-1d05067960f2" });
         
            ViewData["pbireportparams"] = pbirpt;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}