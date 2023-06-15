using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;
using zeeshan_todo_list.Models;

namespace zeeshan_todo_list.Controllers
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



        public IActionResult Logo()
        {
            return View();
        }


        public IActionResult Add()
        {
            DBContext mydb = new DBContext();

            expobj.TbCategory = mydb.TbCategories.ToList();


           

            return View(expobj);
        }


        [HttpPost]
        public IActionResult Add(TbCategory myFormData)
        {
            DBContext mydb = new DBContext();
            mydb.Add(myFormData);
            mydb.SaveChanges();
            expobj.TbCategory = mydb.TbCategories.ToList();
            return View(expobj);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}