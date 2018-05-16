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
    public class KhachHangController : BaseController
    {
        DbSet<KhachHang> dbSet { get => db.KhachHangs; }

        // GET: KhachHang
        public ActionResult Index()
        {
            var KhachHangs = dbSet.Where(q => q.Active != 0);
            return View(KhachHangs.ToList());
        }

        public ActionResult Edit(int? id)
        {
            var obj = id > 0 ? dbSet.Find(id) : new KhachHang();
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(KhachHang obj)
        {
            if (ModelState.IsValid)
            {
                obj.SaveFor(q => q.Logo);
                if (obj.IDKhachHang > 0)
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
