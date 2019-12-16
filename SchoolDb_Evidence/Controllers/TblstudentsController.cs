using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolDb_Evidence;

namespace SchoolDb_Evidence.Controllers
{
    public class TblstudentsController : Controller
    {
        private StudentInformationDbEntities db = new StudentInformationDbEntities();

        // GET: Tblstudents
        public ActionResult Index()
        {
            var tblstudents = db.Tblstudents.Include(t => t.Class).Include(t => t.Gender);
            return View(tblstudents.ToList());
        }

        // GET: Tblstudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tblstudent tblstudent = db.Tblstudents.Find(id);
            if (tblstudent == null)
            {
                return HttpNotFound();
            }
            return View(tblstudent);
        }

        // GET: Tblstudents/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName");
            return View();
        }

        // POST: Tblstudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName,FatherName,MotherName,GenderId,DateOfBirth,ClassId,Phone,Address,Picture")] Tblstudent tblstudent)
        {
            if (ModelState.IsValid)
            {
                db.Tblstudents.Add(tblstudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", tblstudent.ClassId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", tblstudent.GenderId);
            return View(tblstudent);
        }

        // GET: Tblstudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tblstudent tblstudent = db.Tblstudents.Find(id);
            if (tblstudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", tblstudent.ClassId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", tblstudent.GenderId);
            return View(tblstudent);
        }

        // POST: Tblstudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,FatherName,MotherName,GenderId,DateOfBirth,ClassId,Phone,Address,Picture")] Tblstudent tblstudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblstudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", tblstudent.ClassId);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", tblstudent.GenderId);
            return View(tblstudent);
        }

        // GET: Tblstudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tblstudent tblstudent = db.Tblstudents.Find(id);
            if (tblstudent == null)
            {
                return HttpNotFound();
            }
            return View(tblstudent);
        }

        // POST: Tblstudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tblstudent tblstudent = db.Tblstudents.Find(id);
            db.Tblstudents.Remove(tblstudent);
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
