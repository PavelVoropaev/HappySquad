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
            ViewBag.unitList = _db.Units.AsEnumerable().
                Select(unit => new SelectListItem
                                   {
                                       Text = unit.Name,
                                       Value = unit.Id.ToString()
                                   });

            ViewBag.lootList = _db.Loots.AsEnumerable().
                Select(loot => new SelectListItem
                                {
                                    Text = loot.Name,
                                    Value = loot.Id.ToString()
                                });
            return View();
        }

        [HttpPost]
        public ActionResult GetLootByUnitId(string race, string type)
        {
            var units = _db.Units.AsEnumerable().Where(unit => unit.Race.ToString() == race && unit.Type.ToString() == type).ToList();
            return Json(units);
        }

        [HttpPost]
        public ActionResult GetCostById(string id)
        {
            var units = _db.Units.AsEnumerable().Where(unit => unit.Id.ToString() == id).ToList();
            var firstOrDefault = units.FirstOrDefault();
            if (firstOrDefault != null) return Json(firstOrDefault.Cost);
            return Json(0);
        }

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