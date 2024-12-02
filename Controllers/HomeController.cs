using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Data;
using MovieApplication.Dtos.Auth;
using MovieApplication.Models;
using System.Diagnostics;

namespace MovieApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;


        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            ViewBag.Name = "elif";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModelDto item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return View();
        }

        public async Task<IActionResult> Index()
        {

            var test = await _context.Movies.ToListAsync();

            return View(test);
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
