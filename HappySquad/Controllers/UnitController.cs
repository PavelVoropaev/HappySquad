namespace HappySquad.Controllers
{
    using System.Data;
    using System.Data.Entity;
    using System.Data.Objects.SqlClient;
    using System.Linq;
    using System.Web.Mvc;

    using HappySquad.Helpers;
    using HappySquad.Migrations;
    using HappySquad.Models;

    public class UnitController : Controller
    {
        private readonly HappyDbContext db = new HappyDbContext();

        // GET: /Unit/
        public ActionResult Index()
        {
            return View(db.Units.ToList());
        }

        // GET: /Unit/Details/5
        public ActionResult Details(int id = 0)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }

            return View(unit);
        }

        // GET: /Unit/Create
        public ActionResult Create()
        {
            ViewBag.races = DbHelper.GetRaceSelectList();
            ViewBag.unitList = this.db.Units.Select(t => new SelectListItem { Text = t.Name, Value = SqlFunctions.StringConvert((double)t.Id).Trim() }).ToList();
            return View();
        }

        // POST: /Unit/Create
        [HttpPost]
        public ActionResult Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(unit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: /Unit/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Unit unit = db.Units.Find(id);
            if (unit == null)
            {
                return HttpNotFound();
            }

            ViewBag.races = DbHelper.GetRaceSelectList();
            return View(unit);
        }

        // POST: /Unit/Edit/5
        [HttpPost]
        public ActionResult Edit(Unit unit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: /Unit/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Unit unit = db.Units.Find(id);
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
            Unit unit = db.Units.Find(id);
            db.Units.Remove(unit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}