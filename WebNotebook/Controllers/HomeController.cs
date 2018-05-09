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
            //using (var db = new ApplicationDbContext())
            //{
            //    var message = new MessageModels() { Text = "test", UserId = 12 };
            //    db.Messages.Add(message);
            //    db.SaveChanges();
            //}
                return View();
        }
    }
}