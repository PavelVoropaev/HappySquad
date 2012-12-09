namespace HappySquad.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Web.Mvc;

    using HappySquad.Models;

    [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1512:SingleLineCommentsMustNotBeFollowedByBlankLine", Justification = "Reviewed. Suppression is OK here.")]
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
            ViewBag.races = from Race n in Enum.GetValues(typeof(Race))
                            select new SelectListItem
                            {
                                Value = Convert.ToInt16(n).ToString(),
                                Text = HappySquad.Content.Helpers.EnumHelper.GetEnumDescription(n),
                            };

            ViewBag.unitList = this.db.Units.AsEnumerable().Select(
                unit => new SelectListItem
                            {
                                Text = unit.Name,
                                Value = unit.Id.ToString()
                            });

            ViewBag.lootList = this.db.Loots.AsEnumerable().Select(
                loot => new SelectListItem
                            {
                                    Text = loot.Name,
                                    Value = loot.Id.ToString()
                                });
            return View();
        }

        [HttpPost]
        public ActionResult AddUnit(string race, string type)
        {
            var units = this.db.Units.AsEnumerable().Where(unit => unit.Race == (Race)Convert.ToByte(race) && unit.Type.ToString() == type).ToList();
            return Json(units);
        }

        [HttpPost]
        public ActionResult AddLoot(string unitId)
        {
            var loots = new List<Loot>();
            var relations = this.db.Relations.AsEnumerable().Where(relation => relation.UnitId == Convert.ToByte(unitId)).ToList();
            foreach (var relation in relations)
            {
                loots.AddRange(this.db.Loots.Where(loot => loot.Id == relation.LootId));
            }

            return Json(loots);
        }

        [HttpPost]
        public ActionResult SetUnitByPos(string pos, string id)
        {
            var roster = new Roster { UnitId = Convert.ToInt32(id) };
            this.db.Rosters.Add(roster);
            this.db.SaveChanges();
            return Json(roster);
        }

        [HttpPost]
        public ActionResult GetCostById(string id)
        {
            var units = this.db.Units.AsEnumerable().Where(unit => unit.Id.ToString() == id).ToList();
            var firstOrDefault = units.FirstOrDefault();
            return Json(firstOrDefault != null ? firstOrDefault.Cost : 0);
        }

        [HttpPost]
        public ActionResult Create(string name, string race, string unitsId, string lootId)
        {
            if (ModelState.IsValid)
            {
                var unitsIdList = unitsId.Split(',');
                byte i = 0;
                foreach (var unitId in unitsIdList)
                {
                    i++;
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
        public ActionResult Edit(int id = 0)
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