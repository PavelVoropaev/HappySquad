namespace HappySquad.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;

    using HappySquad.Helpers;
    using HappySquad.Models;

    public class RosterController : Controller
    {
        private readonly HappyDbContext db = new HappyDbContext();

        // GET: /Roster/
        public ActionResult Index()
        {
            return View(this.db.Rosters.ToList());
        }

        // GET: /Roster/Details/5
        public ActionResult Details(int id = 0)
        {
            var roster = this.db.Rosters.Find(id);
            if (roster == null)
            {
                return HttpNotFound();
            }

            return View(roster);
        }

        // GET: /Roster/Create
        public ActionResult Create()
        {
            ViewBag.races = DbHelper.GetRaceSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult AddUnit(string race, string type)
        {
            var units = this.db.Units.AsEnumerable().Where(unit => unit.Race == (Race)Convert.ToByte(race) && unit.Type.ToString() == type).ToList();
            return Json(units);
        }

        [HttpPost]
        public ActionResult AddLoot(string unitId, string lootIds)
        {
            var equippedLoots = new List<int>();
            if (!string.IsNullOrEmpty(lootIds))
            {
                equippedLoots = lootIds.Split(',').Select(value => Convert.ToInt32(value)).ToList();
            }

            var relations = this.db.Relations.AsEnumerable().Where(relation => relation.UnitId == Convert.ToByte(unitId)).ToList();
            var mayEquippedLootsId = relations.Select(relation => relation.LootId).ToList();
            foreach (var relation in relations)
            {
                if (equippedLoots.Contains(relation.LootId))
                {
                    mayEquippedLootsId.AddRange(relation.AddLootIdArray.Select(value => Convert.ToInt32(value)).ToList());
                    foreach (var i in relation.ExLootIdArray)
                    {
                        mayEquippedLootsId.Remove(Convert.ToInt32(i));
                    }
                }
            }

            var mayEquippedLoots = new List<Loot>();
            foreach (var lootId in mayEquippedLootsId.Distinct())
            {
                mayEquippedLoots.AddRange(this.db.Loots.Where(loot => loot.Id == lootId));
            }

            return Json(mayEquippedLoots);
        }

        [HttpPost]
        public ActionResult GetUnitById(string unitId)
        {
            var units = this.db.Units.AsEnumerable().Where(unit => unit.Id.ToString() == unitId).ToList();
            return Json(units);
        }

        [HttpPost]
        public ActionResult Create(string name, string race, string unitsId, string lootId)
        {
            if (ModelState.IsValid)
            {
                var unitsIdList = unitsId.Split(',');
                foreach (var unitId in unitsIdList)
                {
                    this.db.Rosters.Add(
                        new Roster
                            {
                                Race = (Race)Convert.ToByte(race),
                                Id = Convert.ToInt32(unitId),
                                RosterName = name
                            });
                }

                this.db.Rosters.Add(new Roster());
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: /Roster/Edit/5
        public ActionResult Edit(int id)
        {
            Roster roster = this.db.Rosters.Find(id);
            if (roster == null)
            {
                return HttpNotFound();
            }

            return View(roster);
        }

        // POST: /Roster/Edit/5
        [HttpPost]
        public ActionResult Edit(Roster roster)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(roster).State = EntityState.Modified;
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roster);
        }

        // GET: /Roster/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Roster roster = this.db.Rosters.Find(id);
            if (roster == null)
            {
                return HttpNotFound();
            }

            return View(roster);
        }

        // POST: /Roster/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Roster roster = this.db.Rosters.Find(id);
            this.db.Rosters.Remove(roster);
            this.db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}