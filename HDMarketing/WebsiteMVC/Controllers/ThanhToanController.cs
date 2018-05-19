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
    public class ThanhToanController : BaseController
    {
        DbSet<ThanhToan> dbSet { get => db.ThanhToans; }

        // GET: ThanhToan
        public ActionResult Index()
        {
            var thanhToans = dbSet.Include(t => t.HopDong).Include(t => t.TaiKhoan);
            return View(thanhToans.ToList());
        }

        public ActionResult Edit(int? id, int? IDHopDong)
        {
            var obj = id > 0 ? dbSet.Find(id) : new ThanhToan()
            {
                IDHopDong = IDHopDong,
                HopDong = db.HopDongs.Find(IDHopDong),
                NgayTT = DateTime.Now,
            };
            if (obj == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHopDongs = db.HopDongs.CreateSelectList(q => q.IDHopDong, q => q.MaHopDong, obj.IDHopDong);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(ThanhToan obj)
        {
            if (ModelState.IsValid)
            {
                obj.NguoiTao = Account.IDTaiKhoan;
                if (obj.IDThanhToan > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    dbSet.Add(obj);
                }
                if (db.SaveChanges() > 0)
                {
                    var hd = db.HopDongs.Find(obj.IDHopDong);
                    hd.DaThanhToan = (hd.DaThanhToan ?? 0) + obj.SoTien;
                    db.SaveChanges();
                    if (hd.DaThanhToan == hd.ChiPhi)
                    {
                        hd.Active = 10;
                        return RedirectToAction("Rate", "HopDong", new { id = hd.IDHopDong });
                    }
                }
                return RedirectToAction("Index", "HopDong");
            }
            ViewBag.IDHopDongs = db.HopDongs.CreateSelectList(q => q.IDHopDong, q => q.MaHopDong, obj.IDHopDong);
            return View(obj);
        }

        // POST: ThanhToan/Delete/5
        public JsonResult Delete(int id)
        {
            var obj = dbSet.Find(id);
            dbSet.Remove(obj);
            return Json(db.SaveChanges());
        }
    }
}
