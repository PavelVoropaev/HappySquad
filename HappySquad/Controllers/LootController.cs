using System.Data;
using System.Linq;
using System.Web.Mvc;
using HappySquad.Models;

namespace HappySquad.Controllers
{
    public class LootController : Controller
    {
        private readonly HappyDbContext _db = new HappyDbContext();

        //
        // GET: /Loot/

        public ActionResult Index()
        {
            return View(_db.Loots.ToList());
        }

        //
        // GET: /Loot/Details/5

        public ActionResult Details(int id = 0)
        {
            Loot loot = _db.Loots.Find(id);
            if (loot == null)
            {
                return HttpNotFound();
            }
            return View(loot);
        }

        //
        // GET: /Loot/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Loot/Create

        [HttpPost]
        public ActionResult Create(Loot loot)
        {
            if (ModelState.IsValid)
            {
                _db.Loots.Add(loot);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loot);
        }

        //
        // GET: /Loot/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Loot loot = _db.Loots.Find(id);
            if (loot == null)
            {
                return HttpNotFound();
            }
            return View(loot);
        }

        //
        // POST: /Loot/Edit/5

        [HttpPost]
        public ActionResult Edit(Loot loot)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(loot).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loot);
        }

        //
        // GET: /Loot/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Loot loot = _db.Loots.Find(id);
            if (loot == null)
            {
                return HttpNotFound();
            }
            return View(loot);
        }

        //
        // POST: /Loot/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Loot loot = _db.Loots.Find(id);
            _db.Loots.Remove(loot);
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