namespace HappySquad.Controllers
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;

    using HappySquad.Models;

    public class UnitController : Controller
    {
        private readonly HappyDbContext db = new HappyDbContext();

        // GET: /Unit/
        public ActionResult Index()
        {
            return View(this.db.Units.ToList());
        }

        // GET: /Unit/Details/5
        public ActionResult Details(int id = 0)
        {
            Unit unit = this.db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }

            return View(unit);
        }

        // GET: /Unit/Create
        public ActionResult Create()
        {
            ViewBag.races = from Race n in Enum.GetValues(typeof(Race))
                            select new SelectListItem
                            {
                                Value = Convert.ToInt16(n).ToString(),
                                Text = HappySquad.Content.Helpers.EnumHelper.GetEnumDescription(n),
                            };
            ViewBag.types = from Models.Type n in Enum.GetValues(typeof(Models.Type))
                            select new SelectListItem
                            {
                                Value = Convert.ToInt16(n).ToString(),
                                Text = HappySquad.Content.Helpers.EnumHelper.GetEnumDescription(n),
                            };
            return View();
        }

        // POST: /Unit/Create
        [HttpPost]
        public ActionResult Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                this.db.Units.Add(unit);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: /Unit/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Unit unit = this.db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }

            return View(unit);
        }

        // POST: /Unit/Edit/5
        [HttpPost]
        public ActionResult Edit(Unit unit)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(unit).State = EntityState.Modified;
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: /Unit/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Unit unit = this.db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }

            return View(unit);
        }

        // POST: /Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit unit = this.db.Units.Find(id);
            this.db.Units.Remove(unit);
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