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

        
        public async Task<IActionResult> Index(int page=1)
        {
            var skip = (page-1)*3;

            var viewModel = new NoteViewModel()
            {
                Notes = await _DatabaseContext.Notes
                .Skip(skip)
                .Take(3)
                .ToListAsync(),

                NewNote = new Note() // An empty note for form submission
            };
            _DatabaseContext.Notes.Include(p => p.Comments).ToList();

            //var viewModel = new NoteViewModel()
            //{
            //    Notes = await _DatabaseContext.Notes.ToListAsync(),
            //    NewNote = new Note() // An empty note for form submission
            //};


            return View(viewModel);
        }


        // New method for loading more notes via AJAX
        [HttpGet]
        public async Task<IActionResult> LoadMore(int page = 1)
        {
            var skip = (page - 1) * 3;

            var notes = await _DatabaseContext.Notes
                .Skip(skip)
                .Take(3)
                .ToListAsync();

             _DatabaseContext.Notes.Include(p => p.Comments).ToList();

            return PartialView("_NotePartialList", notes); // New partial view for loading notes
        }


        [Route("Home/Index", Name = "AddNote")]
        [HttpPost]
        //send data from view but because of different class for sending and getting data from view to controller we have null error
        public async Task<IActionResult> Index(NoteViewModel model)
        {

            Note PersonNote = new Note()
            {
                Content = model.NewNote.Content,
                DatePosted = DateTime.Now,
                SympathyCount = 0
            };


            _DatabaseContext.Notes.Add(PersonNote);
            //error: Cannot insert the value NULL into column
            _DatabaseContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> FilterNotesWithSympathyCount()
        {
           var FilterResult = await _DatabaseContext.Notes.OrderByDescending(x => x.SympathyCount).ToListAsync();

           var viewModel = new NoteViewModel()
           {
               Notes = FilterResult,
           };


            return View("Index",viewModel);
        }

        [Route("Home/AddSympathy", Name = "AddSympathy")]
        [HttpPost]
        public async Task<IActionResult> AddSympathy(int NoteId)
        {
            var note = await _DatabaseContext.Notes.FindAsync(NoteId);

                note.SympathyCount++;
                _DatabaseContext.Notes.Update(note); 
                _DatabaseContext.SaveChangesAsync();
            

            // Return the updated partial view for the note
            return PartialView("_NotePartial", note);
        }

        public async Task<IActionResult> FilterNotesWithDate()
        {
            var FilterResult = await _DatabaseContext.Notes.OrderByDescending(x => x.DatePosted).ToListAsync();
            var viewModel = new NoteViewModel()
            {
                Notes = FilterResult,
            };


            return View("Index", viewModel);
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
