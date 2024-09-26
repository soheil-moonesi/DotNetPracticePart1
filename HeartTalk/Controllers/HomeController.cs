using HeartTalk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HeartTalk.Data;
using Microsoft.EntityFrameworkCore;

namespace HeartTalk.Controllers
{
    public class HomeController : Controller
    {
        public HeartTalkAppContext DatabaseContext = new HeartTalkAppContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            return View(await DatabaseContext.Notes.ToListAsync());
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
