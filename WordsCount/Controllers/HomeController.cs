using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WordsCount.Models;

namespace WordsCount.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string context)
        {
            if(context!=null)
                Counter.Add(context);
            return View();
        }

        public IActionResult English()
        {
            return View();
        }

        public IActionResult Chinese()
        {
            return View();
        }

        public IActionResult Hindi()
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
