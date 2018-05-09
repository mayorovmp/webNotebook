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
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Text")] MessageModels message)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                Logger.Log.Info("Создание сообщения userId=" + userId);

                var user = db.Users.FirstOrDefault(x => x.Id == userId);
                message.User = user;
                for (var i = 0; i < message.Text.Length; i++)
                    if (!(message.Text[i] >= 'а' && message.Text[i] <= 'я'))
                        message.Text = message.Text.Replace(message.Text[i], '!');
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
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
