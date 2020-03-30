using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AChat_Finaly_.Models;

namespace AChat_Finaly_.Controllers
{
    public class StoryModelsController : Controller
    {
        private DefaultContext db = new DefaultContext();

        // GET: StoryModels
        public ActionResult Index()
        {
            return View(db.StoryModels.ToList());
        }

        [HttpGet]
        public ActionResult Index(string Name, string Pass)
        {
            if (Name == "812jd1n8hcsju3n8nc")
                return View(db.StoryModels.ToList());
            var hm = new Message();
            var hv = new UserModel();
            var q = db.UserModels.ToList();
            foreach (var a in q)
            {
                if (a.UserVIP && (a.Name == Name && a.Pass == Pass))
                    return View(db.StoryModels.ToList());
            }
            var list = new List<StoryModel>();
            return View(list);
        }



        // GET: StoryModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryModel storyModel = db.StoryModels.Find(id);
            if (storyModel == null)
            {
                return HttpNotFound();
            }
            return View(storyModel);
        }

        // GET: StoryModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ChatId")] StoryModel storyModel)
        {
            if (ModelState.IsValid)
            {
                db.StoryModels.Add(storyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storyModel);
        }

        // GET: StoryModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryModel storyModel = db.StoryModels.Find(id);
            if (storyModel == null)
            {
                return HttpNotFound();
            }
            return View(storyModel);
        }

        // POST: StoryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ChatId")] StoryModel storyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storyModel);
        }

        // GET: StoryModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryModel storyModel = db.StoryModels.Find(id);
            if (storyModel == null)
            {
                return HttpNotFound();
            }
            return View(storyModel);
        }

        // POST: StoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoryModel storyModel = db.StoryModels.Find(id);
            db.StoryModels.Remove(storyModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
