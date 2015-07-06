using System;
using System.Web.Mvc;
using MvcRefactor.Data;
using MvcRefactor.Entity;
using MvcRefactor.Service;
using MvcRefactor.Logging;

namespace MvcRefactorTest.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;
        private readonly ILogger _logService = new FileLogManager(typeof(HomeController));

        public HomeController(IUserService userServ)
        {
            this.userService = userServ;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var list = userService.GetAll();
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            ViewBag.Message = "System have a issue";

            return View();
        }

        [HttpPost]
        public ActionResult Insert(User objUser)
        {
            return null;
        }

        public ActionResult Insert()
        {
            return View();
        }
    }
}
