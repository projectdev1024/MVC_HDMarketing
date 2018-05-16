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
    public class TaiLieuController : BaseController
    {
        DbSet<TaiLieu> dbSet { get => db.TaiLieux; }

        // GET: TaiLieu
        public ActionResult Index()
        {
            var TaiLieus = dbSet.Include(t => t.HopDong).Include(t => t.TaiKhoan);
            return View(TaiLieus.ToList());
        }

        public ActionResult Edit(int? id, int? IDHopDong)
        {
            var obj = id > 0 ? dbSet.Find(id) : new TaiLieu() { IDHopDong = IDHopDong };
            if (obj == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHopDongs = db.HopDongs.CreateSelectList(q => q.IDHopDong, q => q.MaHopDong, obj.IDHopDong);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(TaiLieu obj)
        {
            if (ModelState.IsValid)
            {
                obj.NguoiTao = Account.IDTaiKhoan;
                obj.NgayTao = DateTime.Now;
                obj.SaveFor(q => q.File);
                if (obj.IDTaiLieu > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    dbSet.Add(obj);
                }
                db.SaveChanges();
                return RedirectToAction("Index","HopDong");
            }
            ViewBag.IDHopDongs = db.HopDongs.CreateSelectList(q => q.IDHopDong, q => q.MaHopDong, obj.IDHopDong);
            return View(obj);
        }

        // POST: TaiLieu/Delete/5
        public JsonResult Delete(int id)
        {
            var obj = dbSet.Find(id);
            if (System.IO.File.Exists(obj.File)) System.IO.File.Delete(obj.File);
            dbSet.Remove(obj);
            return Json(db.SaveChanges());
        }
    }
}
