using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using HappySquad.Models;

namespace HappySquad.Controllers
{
    public class RelationController : Controller
    {
        private readonly HappyDbContext _db = new HappyDbContext();

        //
        // GET: /Relation/

        public ActionResult Index()
        {
            return View(_db.Relations.ToList());
        }

        //
        // GET: /Relation/Details/5

        public ActionResult Details(int id = 0)
        {
            Relation relation = _db.Relations.Find(id);
            if (relation == null)
            {
                return HttpNotFound();
            }
            return View(relation);
        }

        //
        // GET: /Relation/Create

        public ActionResult Create()
        {
           
            return View();
        }

        //
        // POST: /Relation/Create

        [HttpPost]
        public ActionResult Create(Relation relation)
        {
            if (ModelState.IsValid)
            {
                _db.Relations.Add(relation);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relation);
        }

        //
        // GET: /Relation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Relation relation = _db.Relations.Find(id);
            if (relation == null)
            {
                return HttpNotFound();
            }
            return View(relation);
        }

        //
        // POST: /Relation/Edit/5

        [HttpPost]
        public ActionResult Edit(Relation relation)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(relation).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relation);
        }

        //
        // GET: /Relation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Relation relation = _db.Relations.Find(id);
            if (relation == null)
            {
                return HttpNotFound();
            }
            return View(relation);
        }

        //
        // POST: /Relation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Relation relation = _db.Relations.Find(id);
            _db.Relations.Remove(relation);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}