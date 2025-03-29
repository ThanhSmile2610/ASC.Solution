using ASC.WEB.Configuration;
using ASC.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using ASC.Utilities;

namespace ASC.WEB.Controllers
{
    public class HomeController : AnonymousController
    {
        //private readonly ILogger<HomeController> _logger;
        private IOptions<ApplicationSettings> _settings;
        public HomeController(IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
        }

        //public HomeController(ILogger<HomeController> logger , IOptions<ApplicationSettings> settings)
        //{
        //    _logger = logger;
        //    _settings = settings;

        //}

        public IActionResult Index()
        {
            // Set Session 
            HttpContext.Session.SetSession("Test", _settings.Value);
            // Get Session 
            var settings = HttpContext.Session.GetSession<ApplicationSettings>("Test");
            // Usage of IOptions
            ViewBag.Title = _settings.Value.ApplicationTitle;
            return View();
            //Test case fail
            //ViewData.Model = "Test";
            //throw new Exception("Login Fail!!!");
            //return View();
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
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
