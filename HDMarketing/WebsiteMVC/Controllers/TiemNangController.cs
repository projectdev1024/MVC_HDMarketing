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
    public class TiemNangController : BaseController
    {
        DbSet<TiemNang> dbSet { get => db.TiemNangs; }

        // GET: TiemNang
        public ActionResult Index()
        {
            var TiemNangs = dbSet.Where(q => q.State != 0);
            return View(TiemNangs.ToList());
        }

        public ActionResult Edit(int? id)
        {
            var obj = id > 0 ? dbSet.Find(id) : new TiemNang();
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(TiemNang obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.IDTiemNang > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    obj.State = 1;
                    dbSet.Add(obj);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public JsonResult Delete(int id)
        {
            var obj = dbSet.Find(id);
            obj.State = 0;
            return Json(db.SaveChanges());
        }

        public JsonResult Active(int id)
        {
            var obj = dbSet.Find(id);
            obj.State = (byte)(obj.State != 1 ? 1 : 2);
            return Json(db.SaveChanges());
        }
    }
}
