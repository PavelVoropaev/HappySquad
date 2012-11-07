using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using HappySquad.Models;

namespace HappySquad.Controllers
{
    public class RosterController : Controller
    {
        private readonly HappyDbContext _db = new HappyDbContext();

        //
        // GET: /Roster/

        public ActionResult Index()
        {
            return View(_db.Rosters.ToList());
        }

        //
        // GET: /Roster/Details/5

        public ActionResult Details(int id = 0)
        {
            var roster = _db.Rosters.Find(id);
            if (roster == null)
            {
                return HttpNotFound();
            }
            return View(roster);
        }

        //
        // GET: /Roster/Create

        public ActionResult Create()
        {
              var units = new List<SelectListItem>();
            foreach (var t in _db.Units)
            {
                var s = new SelectListItem { Text = t.Name, Value = t.Id.ToString() };
                units.Add(s);
            }
            ViewBag.unitList = units;

            var loots = new List<SelectListItem>();
            foreach (var t in _db.Loots)
            {
                var s = new SelectListItem { Text = t.Name, Value = t.Id.ToString() };
                loots.Add(s);
            }
            ViewBag.lootList = loots;
            return View();
        }

        //
        // POST: /Roster/Create

        [HttpPost]
        public ActionResult Create(List<Roster> rosters)
        {
            if (ModelState.IsValid)
            {
                foreach (var roster in rosters)
                {
                _db.Rosters.Add(roster);
                _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(rosters.FirstOrDefault());
        }

        //
        // GET: /Roster/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Roster roster = _db.Rosters.Find(id);
            if (roster == null)
            {
                return HttpNotFound();
            }
            return View(roster);
        }

        //
        // POST: /Roster/Edit/5

        [HttpPost]
        public ActionResult Edit(Roster roster)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(roster).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roster);
        }

        //
        // GET: /Roster/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Roster roster = _db.Rosters.Find(id);
            if (roster == null)
            {
                return HttpNotFound();
            }
            return View(roster);
        }

        //
        // POST: /Roster/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Roster roster = _db.Rosters.Find(id);
            _db.Rosters.Remove(roster);
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