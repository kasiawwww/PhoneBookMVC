using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneBookMVC.Models;

namespace PhoneBookMVC.Controllers
{
    public class MoneyForPersonsController : Controller
    {
        private DbEntities db = new DbEntities();

        // GET: MoneyForPersons
        public ActionResult Index()
        {
            var moneyForPerson = db.MoneyForPerson.Include(m => m.Person);
            return View(moneyForPerson.ToList());
        }

        // GET: MoneyForPersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyForPerson moneyForPerson = db.MoneyForPerson.Find(id);
            if (moneyForPerson == null)
            {
                return HttpNotFound();
            }
            return View(moneyForPerson);
        }

        // GET: MoneyForPersons/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.Person, "Id", "Name");
            return View();
        }

        // POST: MoneyForPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonId,Salary")] MoneyForPerson moneyForPerson)
        {
            if (ModelState.IsValid)
            {
                db.MoneyForPerson.Add(moneyForPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.Person, "Id", "Name", moneyForPerson.PersonId);
            return View(moneyForPerson);
        }

        // GET: MoneyForPersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyForPerson moneyForPerson = db.MoneyForPerson.Find(id);
            if (moneyForPerson == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.Person, "Id", "Name", moneyForPerson.PersonId);
            return View(moneyForPerson);
        }

        // POST: MoneyForPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonId,Salary")] MoneyForPerson moneyForPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moneyForPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.Person, "Id", "Name", moneyForPerson.PersonId);
            return View(moneyForPerson);
        }

        // GET: MoneyForPersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyForPerson moneyForPerson = db.MoneyForPerson.Find(id);
            if (moneyForPerson == null)
            {
                return HttpNotFound();
            }
            return View(moneyForPerson);
        }

        // POST: MoneyForPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoneyForPerson moneyForPerson = db.MoneyForPerson.Find(id);
            db.MoneyForPerson.Remove(moneyForPerson);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
