using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordCreator.Models;

namespace WordCreator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        public HomeController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            CreateTextDocument textDocument = new CreateTextDocument();
            textDocument.CreateDocument(user);
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Files/test.txt");
            string file_type = "application/txt";
            string file_name = "test.txt";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
