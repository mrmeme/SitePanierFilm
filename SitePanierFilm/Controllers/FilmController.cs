using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitePanierFilm.Models;

namespace SitePanierFilm.Controllers
{
    public class FilmController : Controller
    {
        private site_marchandEntities db = new site_marchandEntities();

        //
        // GET: /Film/

        public ActionResult Index()
        {
            var film = db.Film.Include(f => f.Category);
            return View(film.ToList());
        }

        //
        // GET: /Film/Details/5

        public ActionResult Details(int id = 0)
        {
            Film film = db.Film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        //
        // GET: /Film/Create

        public ActionResult Create()
        {
            ViewBag.Category_id = new SelectList(db.Category, "Id", "Name");
            return View();
        }

        //
        // POST: /Film/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                db.Film.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_id = new SelectList(db.Category, "Id", "Name", film.Category_id);
            return View(film);
        }

        //
        // GET: /Film/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Film film = db.Film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_id = new SelectList(db.Category, "Id", "Name", film.Category_id);
            return View(film);
        }

        //
        // POST: /Film/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_id = new SelectList(db.Category, "Id", "Name", film.Category_id);
            return View(film);
        }

        //
        // GET: /Film/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Film film = db.Film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        //
        // POST: /Film/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Film.Find(id);
            db.Film.Remove(film);
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