using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteMVC.Models;

namespace WebsiteMVC.Controllers
{
    [RoleAccept(eRole.ADMIN)]
    public class LoaiHDController : BaseController
    {
        DbSet<LoaiHD> dbSet { get => db.LoaiHDs; }

        // GET: LoaiHD
        public ActionResult Index()
        {
            return View(dbSet.Where(q => q.Active != 0));
        }

        public ActionResult Edit(int? id)
        {
            var obj = id > 0 ? dbSet.Find(id) : new LoaiHD();
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(LoaiHD obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.IDLoaiHD > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    obj.Active = 1;
                    dbSet.Add(obj);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // POST: LoaiHD/Delete/5
        public JsonResult Delete(int id)
        {
            var obj = dbSet.Find(id);
            obj.Active = 0;
            return Json(db.SaveChanges());
        }

        public JsonResult Active(int id)
        {
            var obj = dbSet.Find(id);
            obj.Active = (byte)(obj.Active != 1 ? 1 : 2);
            return Json(db.SaveChanges());
        }
    }
}
