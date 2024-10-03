using HeartTalk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HeartTalk.Data;
using Microsoft.EntityFrameworkCore;

namespace HeartTalk.Controllers
{
    public class HomeController : Controller
    {
       // public HeartTalkAppContext DatabaseContext = new HeartTalkAppContext();

        private readonly ILogger<HomeController> _logger;
        private readonly HeartTalkAppContext _DatabaseContext;

        public HomeController(ILogger<HomeController> logger,HeartTalkAppContext DatabaseContext)
        {
            _logger = logger;
            _DatabaseContext = DatabaseContext;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            return View(await _DatabaseContext.Notes.ToListAsync());
        }

        public async Task<IActionResult> FilterNotesWithSympathyCount()
        {
           var FilterResult = await _DatabaseContext.Notes.OrderByDescending(x => x.SympathyCount).ToListAsync();
            return View("Index",FilterResult);
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
