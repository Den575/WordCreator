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
            CreateWord createWord = new CreateWord();
            createWord.Create(user);


            string file_path = Path.Combine(_appEnvironment.ContentRootPath, $"Files/{user.Name} {user.Surname}.docx");
            string file_type = "application/docx";
            string file_name = $"{user.Name} {user.Surname}.docx";
            return PhysicalFile(file_path, file_type, file_name);
            //return View("DocumentInfo");
        }

        public IActionResult DataBase() => View();
    }
}
