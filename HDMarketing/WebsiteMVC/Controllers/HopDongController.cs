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
    public class HopDongController : BaseController
    {
        DbSet<HopDong> dbSet { get => db.HopDongs; }

        // GET: HopDong
        public ActionResult Index(string sfromDate, string stoDate, int? IDLoaiHD)
        {
            var fromDate = sfromDate.ToDate();
            var toDate = stoDate.ToDate();
            if (sfromDate == null)
            {
                fromDate = toDate.AddMonths(-1);
            }

            var lst = dbSet.Where(q => q.Active != 0 && q.NgayKy >= fromDate && q.NgayKy <= toDate);

            ViewBag.fromDate = fromDate.ToString("yyyy-MM-dd");
            ViewBag.toDate = toDate.ToString("yyyy-MM-dd");

            if (IDLoaiHD.HasValue) lst = lst.Where(q => q.IDLoaiHD == IDLoaiHD);
            ViewBag.IDLoaiHDs = db.LoaiHDs.OrderBy(q => q.TenLoaiHD).CreateSelectList(q => q.IDLoaiHD, q => q.TenLoaiHD, IDLoaiHD);

            return View(lst.ToList());
        }

        public ActionResult Rate(int? id)
        {
            var obj = db.HopDongs.Find(id);
            if (obj == null || obj.ChiPhi < obj.DaThanhToan)
            {
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Rate(int id, byte? ratedv = 1, byte? ratenv = 1)
        {
            var obj = dbSet.Find(id);
            if (obj != null)
            {
                obj.Rate = ratedv;
                obj.TaiKhoan.Rate = (byte)((obj.TaiKhoan.Rate * obj.TaiKhoan.SoHD + ratenv) / (obj.TaiKhoan.SoHD + 1));
                obj.TaiKhoan.SoHD++;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            var obj = id > 0 ? dbSet.Find(id) : new HopDong();
            if (obj == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKhachHang = db.KhachHangs.CreateSelectList(q => q.IDKhachHang, q => q.CongTy, obj.IDKhachHang);
            ViewBag.IDLoaiHDs = db.LoaiHDs.CreateSelectList(q => q.IDLoaiHD, q => q.MaLoaiHD, obj.IDLoaiHD);
            ViewBag.NguoiPhuTrachs = db.TaiKhoans.CreateSelectList(q => q.IDTaiKhoan, q => q.FullName, obj.NguoiPhuTrach);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(HopDong obj)
        {
            if (ModelState.IsValid)
            {
                obj.NguoiTao = Account.IDTaiKhoan;
                obj.NgayTao = DateTime.Now;
                if (obj.IDHopDong > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    obj.Active = 1;
                    obj.Rate = 0;
                    obj.DaThanhToan = 0;
                    dbSet.Add(obj);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKhachHang = db.KhachHangs.CreateSelectList(q => q.IDKhachHang, q => q.CongTy, obj.IDKhachHang);
            ViewBag.IDLoaiHDs = db.LoaiHDs.CreateSelectList(q => q.IDLoaiHD, q => q.MaLoaiHD, obj.IDLoaiHD);
            ViewBag.NguoiPhuTrachs = db.TaiKhoans.CreateSelectList(q => q.IDTaiKhoan, q => q.FullName, obj.NguoiPhuTrach);
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
