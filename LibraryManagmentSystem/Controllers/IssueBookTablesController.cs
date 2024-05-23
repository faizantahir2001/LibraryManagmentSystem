using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer;

namespace LibraryManagmentSystem.Controllers
{
    public class IssueBookTablesController : Controller
    {
        private OnlineLibraryMgtSystemDbEntities db = new OnlineLibraryMgtSystemDbEntities();

        // GET: IssueBookTables
        public ActionResult Index()
        {
            var issueBookTables = db.IssueBookTables.Include(i => i.BookTable).Include(i => i.EmployeeTable).Include(i => i.UserTable);
            return View(issueBookTables.ToList());
        }

        // GET: IssueBookTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBookTable issueBookTable = db.IssueBookTables.Find(id);
            if (issueBookTable == null)
            {
                return HttpNotFound();
            }
            return View(issueBookTable);
        }

        // GET: IssueBookTables/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.BookTables, "BookID", "BookTitle");
            ViewBag.EmployeeID = new SelectList(db.EmployeeTables, "EmployeeID", "FullName");
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "UserName");
            return View();
        }

        // POST: IssueBookTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IssueBookID,UserID,BookID,EmployeeID,IssueCopies,IssueDate,ReturnDate,Status,Description,ReserveNoOfCopies")] IssueBookTable issueBookTable)
        {
            if (ModelState.IsValid)
            {
                db.IssueBookTables.Add(issueBookTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.BookTables, "BookID", "BookTitle", issueBookTable.BookID);
            ViewBag.EmployeeID = new SelectList(db.EmployeeTables, "EmployeeID", "FullName", issueBookTable.EmployeeID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "UserName", issueBookTable.UserID);
            return View(issueBookTable);
        }

        // GET: IssueBookTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBookTable issueBookTable = db.IssueBookTables.Find(id);
            if (issueBookTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.BookTables, "BookID", "BookTitle", issueBookTable.BookID);
            ViewBag.EmployeeID = new SelectList(db.EmployeeTables, "EmployeeID", "FullName", issueBookTable.EmployeeID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "UserName", issueBookTable.UserID);
            return View(issueBookTable);
        }

        // POST: IssueBookTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IssueBookID,UserID,BookID,EmployeeID,IssueCopies,IssueDate,ReturnDate,Status,Description,ReserveNoOfCopies")] IssueBookTable issueBookTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(issueBookTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.BookTables, "BookID", "BookTitle", issueBookTable.BookID);
            ViewBag.EmployeeID = new SelectList(db.EmployeeTables, "EmployeeID", "FullName", issueBookTable.EmployeeID);
            ViewBag.UserID = new SelectList(db.UserTables, "UserID", "UserName", issueBookTable.UserID);
            return View(issueBookTable);
        }

        // GET: IssueBookTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IssueBookTable issueBookTable = db.IssueBookTables.Find(id);
            if (issueBookTable == null)
            {
                return HttpNotFound();
            }
            return View(issueBookTable);
        }

        // POST: IssueBookTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IssueBookTable issueBookTable = db.IssueBookTables.Find(id);
            db.IssueBookTables.Remove(issueBookTable);
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
