using Day7_hw.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Day7_hw.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetJson()
        {
            //string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/users.json");
            //var jsonOptions = new System.Text.Json.JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true,
            //    WriteIndented = true
            //};
            //return Json(FilePath);

            using (FileStream fs = new FileStream(@"C:\Users\Home\source\repos\Day7-hw\Day7-hw\Files\users.json", FileMode.OpenOrCreate))
            {
                object? obj = System.Text.Json.JsonSerializer.Deserialize<object>(fs);
                return Json(obj);
            }
        }
    }
}