using AChat_Finaly_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AChat_Finaly_.Controllers
{
    public class HomeController : Controller
    {
        private DefaultContext db = new DefaultContext();
        public ActionResult Index()
        {
            return View(db.StoryModels.ToList());
        }
        public ActionResult Chat()
        {
            ViewBag.Message = "Chat page.";
            
            return View();
        }
    }
}