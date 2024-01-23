using Microsoft.AspNetCore.Mvc;
using NTD_TEST.Data;
using NTD_TEST.Models;
using System.Diagnostics;

namespace NTD_TEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private StudentDbContext stdContext;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var connectionString = _configuration.GetConnectionString("MyDb");
            using (var stdContext = new StudentDbContext(connectionString))
            {
                var students = stdContext.Student.ToList();
                Debug.WriteLine("---------------------------------------------------------");
                foreach (var student in students)
                {
                    Debug.WriteLine("---------------------------------------------------------");
                    Debug.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
                }
                return View(students);
            }
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
