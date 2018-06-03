using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNotebook.Models;

namespace WebNotebook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                return View();
        }
    }
}