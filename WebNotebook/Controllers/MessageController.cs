using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using log4net;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebNotebook.Models;
using WebNotebook.Utils;

namespace WebNotebook.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Message
        public ActionResult Index()
        {
            var users = db.Messages.Include("User").ToList();
            return View(users);
        }


        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageModels/Create
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Text")] MessageModels message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = User.Identity.GetUserId();

                    Logger.Log.Info("Создание сообщения userId=" + userId);

                    var user = db.Users.FirstOrDefault(x => x.Id == userId);
                    message.User = user;
                    message.Text = message.Text.Substring(0, Math.Min(message.Text.Length, 100));
                    for (var i = 0; i < message.Text.Length; i++)
                        if (!(message.Text[i] >= 'а' && message.Text[i] <= 'я'
                            || message.Text[i] >= 'А' && message.Text[i] <= 'Я'
                            || message.Text[i] == ' '
                            || message.Text[i] == '!'
                            || message.Text[i] == '?'
                            || message.Text[i] == '.'
                            || message.Text[i] == ','))
                            message.Text = message.Text.Replace(message.Text[i], '!');
                    db.Messages.Add(message);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                Logger.Log.Error(e.Message);
            }
            return View(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
