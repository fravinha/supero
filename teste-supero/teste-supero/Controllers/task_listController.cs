using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using teste_supero.Models;

namespace teste_supero.Controllers
{
    public class task_listController : Controller
    {
        private superoEntities db = new superoEntities();

        // GET: task_list
        public ActionResult Index()
        {
            return View(db.task_list.ToList());
        }

        // GET: task_list/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task_list task_list = db.task_list.Find(id);
            if (task_list == null)
            {
                return HttpNotFound();
            }
            return View(task_list);
        }

        // GET: task_list/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,titulo,descricao,concluido,dataInclusao,dataAlteracao")] task_list task_list)
        {
            if (ModelState.IsValid)
            {
                task_list.dataInclusao = DateTime.Now;
                db.task_list.Add(task_list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task_list);
        }

        // GET: task_list/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task_list task_list = db.task_list.Find(id);
            if (task_list == null)
            {
                return HttpNotFound();
            }
            return View(task_list);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,titulo,descricao,concluido,dataInclusao,dataAlteracao")] task_list task_list)
        {
            if (ModelState.IsValid)
            {
                task_list.dataAlteracao = DateTime.Now;
                db.Entry(task_list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task_list);
        }

        // GET: task_list/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task_list task_list = db.task_list.Find(id);
            if (task_list == null)
            {
                return HttpNotFound();
            }
            return View(task_list);
        }

        // POST: task_list/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            task_list task_list = db.task_list.Find(id);
            db.task_list.Remove(task_list);
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
