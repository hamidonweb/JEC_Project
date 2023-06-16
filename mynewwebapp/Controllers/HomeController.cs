using Microsoft.AspNetCore.Mvc;
using mynewwebapp.Models;
using System.Diagnostics;
using System.Dynamic;

namespace mynewwebapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        dynamic expobj;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            expobj = new ExpandoObject();
        }

        public IActionResult Index()
        {
            DBContext mydb = new DBContext();
            expobj.TbCategory = mydb.TbCategories.ToList();
            expobj.TbTodo = mydb.TbTodos.ToList();
            expobj.TbUser = mydb.TbUsers.ToList();



            return View(expobj);
        }

        [HttpPost]
        public IActionResult Index(TbTodo myFormData)
        {
            DBContext mydb = new DBContext();

            mydb.Add(myFormData);
            mydb.SaveChanges();

            expobj.TbCategory = mydb.TbCategories.ToList();
            expobj.TbTodo = mydb.TbTodos.ToList();
            expobj.TbUser = mydb.TbUsers.ToList();



            return View(expobj);
        }

        public IActionResult About()
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
    }
}