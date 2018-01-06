using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeetingOrganizer.Models;

namespace MeetingOrganizer.Controllers
{
    public class MeetingController : Controller
    {
        private MeetingOrganizerEntities db = new MeetingOrganizerEntities();

        //
        // GET: /Meeting/

        public ActionResult Index()
        {
            var tbl_meetings = db.tbl_Meetings.Include(t => t.tbl_Participants);
            return View(tbl_meetings.ToList());
        }

        //
        // GET: /Meeting/Details/5

        public ActionResult Details(int id = 0)
        {
            tbl_Meetings tbl_meetings = db.tbl_Meetings.Find(id);
            if (tbl_meetings == null)
            {
                return HttpNotFound();
            }
            return View(tbl_meetings);
        }

        //
        // GET: /Meeting/Create

        public ActionResult Create()
        {
            ViewBag.ParticipantID = new SelectList(db.tbl_Participants, "ParticipantID", "Name");
            return View();
        }

        //
        // POST: /Meeting/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Meetings tbl_meetings)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Meetings.Add(tbl_meetings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParticipantID = new SelectList(db.tbl_Participants, "ParticipantID", "Name", tbl_meetings.ParticipantID);
            return View(tbl_meetings);
        }

        //
        // GET: /Meeting/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tbl_Meetings tbl_meetings = db.tbl_Meetings.Find(id);
            if (tbl_meetings == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParticipantID = new SelectList(db.tbl_Participants, "ParticipantID", "Name", tbl_meetings.ParticipantID);
            return View(tbl_meetings);
        }

        //
        // POST: /Meeting/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tbl_Meetings tbl_meetings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_meetings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParticipantID = new SelectList(db.tbl_Participants, "ParticipantID", "Name", tbl_meetings.ParticipantID);
            return View(tbl_meetings);
        }

        //
        // GET: /Meeting/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tbl_Meetings tbl_meetings = db.tbl_Meetings.Find(id);
            if (tbl_meetings == null)
            {
                return HttpNotFound();
            }
            return View(tbl_meetings);
        }

        //
        // POST: /Meeting/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Meetings tbl_meetings = db.tbl_Meetings.Find(id);
            db.tbl_Meetings.Remove(tbl_meetings);
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