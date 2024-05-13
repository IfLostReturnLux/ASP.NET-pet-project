using Diplom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    public class FileController : Controller
    {
        IWebHostEnvironment _env;
        string filesPath;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
            filesPath = _env.ContentRootPath + @"/Resources/Files/";
        }

        public class MyPath
        {
            public string Text { get; set; }
        }
        [HttpGet]
        public IActionResult Index()
        {

            FilePageModel model = new FilePageModel();
            var directories = Directory.GetDirectories(filesPath).Select(item => Path.GetFileName(item)).ToList();
            var files = Directory.GetFiles(filesPath).Select(item => Path.GetFileName(item)).ToList();
            model.DirectoriesName = directories;
            model.FilesName = files;

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult ChangeDirectory()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string path = sr.ReadToEndAsync().Result + @"\";
            path = path.Replace("/", @"\");
            
            FilePageModel model = new FilePageModel();
            var directories = Directory.GetDirectories(filesPath + path).Select(item => Path.GetFileName(item)).ToList();
            var files = Directory.GetFiles(filesPath + path).Select(item => Path.GetFileName(item)).ToList();
            Console.WriteLine(_env.ContentRootPath + path);
            Console.WriteLine(files.Count);
            model.DirectoriesName = directories;
            model.FilesName = files;

            return PartialView("FileView", model);
        }
    }
}
