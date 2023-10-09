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
            pbirpt.Add(new PowerBI() { WorkspaceId = "4f1328db-30aa-46a2-8b58-1337f6c7e623", ReportId= "44358590-dfeb-452b-a598-dc5834bc820a" });
         
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