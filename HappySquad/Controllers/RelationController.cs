namespace HappySquad.Controllers
{
    using System.Data;
    using System.Data.Objects.SqlClient;
    using System.Linq;
    using System.Web.Mvc;
    using HappySquad.Models;

    public class RelationController : Controller
    {
        private readonly HappyDbContext db = new HappyDbContext();

        // GET: /Relation/
        public ActionResult Index()
        {
            return View(this.db.Relations.ToList());
        }

        // GET: /Relation/Details/5
        public ActionResult Details(int id = 0)
        {
            Relation relation = this.db.Relations.Find(id);
            if (relation == null)
            {
                return HttpNotFound();
            }

            return View(relation);
        }

        // GET: /Relation/Create
        public ActionResult Create()
        {
            this.ViewBag.unitList = this.db.Units.Select(t => new SelectListItem { Text = t.Name, Value = SqlFunctions.StringConvert((double)t.Id).Trim() }).ToList();
            this.ViewBag.lootList = this.db.Loots.Select(t => new SelectListItem { Text = t.Name, Value = SqlFunctions.StringConvert((double)t.Id).Trim() }).ToList();

            return View();
        }

        // POST: /Relation/Create
        [HttpPost]
        public ActionResult Create(Relation relation)
        {
            if (ModelState.IsValid)
            {
                this.db.Relations.Add(relation);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relation);
        }

        // GET: /Relation/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var relation = this.db.Relations.Find(id);
            if (relation == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.unitList = this.db.Units.Select(t => new SelectListItem { Text = t.Name, Value = SqlFunctions.StringConvert((double)t.Id).Trim() }).ToList();
            this.ViewBag.lootList = this.db.Loots.Select(t => new SelectListItem { Text = t.Name, Value = SqlFunctions.StringConvert((double)t.Id).Trim() }).ToList();

            return View(relation);
        }

        // POST: /Relation/Edit/5
        [HttpPost]
        public ActionResult Edit(Relation relation)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(relation).State = EntityState.Modified;
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relation);
        }

        // GET: /Relation/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Relation relation = this.db.Relations.Find(id);
            if (relation == null)
            {
                return HttpNotFound();
            }

            return View(relation);
        }

        // POST: /Relation/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Relation relation = this.db.Relations.Find(id);
            this.db.Relations.Remove(relation);
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