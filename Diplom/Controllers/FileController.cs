using Diplom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Diplom.Controllers
{
    public class FileController : Controller
    {
        IWebHostEnvironment _env;
        string filesPath;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
            filesPath = _env.ContentRootPath + @"\Resources\Files";

            CheckFiles();
        }

        void CheckFiles()
        {
            AppDbContext db = new AppDbContext();
            var foldersNames = db.rolelist.ToList();
            foreach (var item in foldersNames)
            {
                if (!Directory.Exists(filesPath + @$"\{item.Name}"))
                {
                    Console.WriteLine("Directory was not exist:" + item.Name);
                    Directory.CreateDirectory(filesPath + @$"\{item.Name}");
                }
            }
        }


        [HttpGet]
        public IActionResult Index()
        {

            FilePageModel model = new FilePageModel();


            var userRoles = User.FindFirst("Roles").Value.Split(',');
            List<string> drc = new List<string>();

            foreach (var userRole in userRoles)
            {
                drc.Add(userRole.ToString());
                 //drc = Directory.GetDirectories(filesPath +$@"\{userRole}").Select(item => Path.GetFileName(item)).ToList();
            }
      
            var directories = Directory.GetDirectories(filesPath).Select(item => Path.GetFileName(item)).ToList();
            var files = Directory.GetFiles(filesPath).Select(item => Path.GetFileName(item)).ToList();
            model.DirectoriesName = drc;
            model.FilesName = files;


            return View("Index", model);
        }

        [HttpPost]
        public IActionResult ChangeDirectory()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string path = sr.ReadToEndAsync().Result + @"/";

            FilePageModel model = new FilePageModel();

            model.Path = path;

            var directories = Directory.GetDirectories(filesPath + path).Select(item => Path.GetFileName(item)).ToList();
            var files = Directory.GetFiles(filesPath + path).Select(item => Path.GetFileName(item)).ToList();
            Console.WriteLine(filesPath + path);

            model.DirectoriesName = directories;
            model.FilesName = files;
       

            return PartialView("FileView", model);
        }

        public IActionResult Back()
        {
            FilePageModel model = new FilePageModel();
            List<string> foldersInPath = new List<string>();
            StreamReader sr = new StreamReader(Request.Body);
            string path = sr.ReadToEndAsync().Result;
            Console.WriteLine("Path =" + path);
            foldersInPath = path.Split(@"/").ToList();

            foldersInPath.RemoveAt(foldersInPath.Count - 2);

            path = string.Join(@"/", foldersInPath);
            Console.WriteLine("Путь" + path);
            if (path == @"" || path == @"/")
            {
                var userRoles = User.FindAll("Roles").ToList();

                List<string> drc = new List<string>();
                foreach (var userRole in userRoles)
                {
                    drc.Add(userRole.Value.ToString());
                }
                model.DirectoriesName = drc;
            }
            else
            {
                var directories = Directory.GetDirectories(filesPath + path).Select(item => Path.GetFileName(item)).ToList();
                var files = Directory.GetFiles(filesPath + path).Select(item => Path.GetFileName(item)).ToList();
                model.DirectoriesName = directories;
                model.FilesName = files;
            }
            
            Console.WriteLine(filesPath + path);
            model.Path = path;


            return PartialView("FileView", model);
        }

        [HttpPost]
        public async Task<IActionResult> DownloadFile ()
        {
            StreamReader sr = new StreamReader(Request.Body);
            string path = filesPath + sr.ReadToEndAsync().Result;
            Console.WriteLine(path);

            string fileName = Path.GetFileName(path);
            Console.WriteLine("Имя файла:" +fileName);

            if (!System.IO.File.Exists(path))
            {
                return NotFound(); // Вернуть 404, если файл не найден
            }

            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
               await stream.CopyToAsync(memory, 8192); // Копирование файла в память с буфером 8 кБ
            }

            memory.Position = 0;
            //byte[] content = System.IO.File.ReadAllBytes(path);
            var contentType = "application/octet-stream";
;
            return File(memory, contentType  , fileName);
        }
    }
}
