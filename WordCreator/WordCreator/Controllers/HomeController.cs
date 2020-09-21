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
        private object filepath;

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
            CreateTextDocument createText = new CreateTextDocument();
            createText.AddToDataBase(user);

            string file_path = Path.Combine(_appEnvironment.ContentRootPath, $"Files/{user.Name} {user.Surname}.docx");
            string file_type = "application/docx";
            string file_name = $"{user.Name} {user.Surname}.docx";
            return PhysicalFile(file_path, file_type, file_name);
        }

        public IActionResult DataBase()
        {
            CreateTextDocument create = new CreateTextDocument();
            return View(create.GetUser());
        }

        public IActionResult DeleteAll()
        {
            using (StreamWriter sw = new StreamWriter(@"Files\data.json", false)) { }
            return Redirect("DataBase");
        }
    }
}
