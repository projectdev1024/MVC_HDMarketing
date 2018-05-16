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
    public class TaiKhoanController : BaseController
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View(db.TaiKhoans.ToList().Where(q => q.Active != 0).ToList());
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldpass, string newpass, string repass)
        {
            if (newpass != repass)
            {
                ModelState.AddModelError("", "Xác nhận mật khẩu không chính xác.");
            }
            if (newpass.Length < 8)
            {
                ModelState.AddModelError("", "Nhập mật khẩu có ít nhất 08 tí tự.");
            }
            if (oldpass.Length < 0)
            {
                ModelState.AddModelError("", "Vui lòng nhập mật khẩu cũ.");
            }
            if (ModelState.ContainsKey("") == false)
            {
                var db = new Models.HDMarketingEntities();
                var acc = db.TaiKhoans.FirstOrDefault(q => q.IDTaiKhoan == Account.IDTaiKhoan);
                if (acc.Password == oldpass)
                {
                    acc.Password = repass;
                    db.SaveChanges();
                    return RedirectToAction("Logout", "Login", new { area = "" });
                }
                ModelState.AddModelError("", "Mật khẩu cũ không chính xác");
            }
            return View();
        }

        // GET: TaiKhoan/Edit/5
        public ActionResult Edit(int? id)
        {
            TaiKhoan obj = new TaiKhoan();
            if (id > 0)
            {
                obj = db.TaiKhoans.Find(id);
                if (obj == null)
                {
                    return HttpNotFound();
                }
            }
            return View(obj);
        }

        // POST: TaiKhoan/Edit/5
        [HttpPost]
        public ActionResult Edit(TaiKhoan obj)
        {
            if (ModelState.IsValid)
            {
                obj.SaveFor(q => q.Avatar);

                if (obj.IDTaiKhoan > 0)
                {
                    db.Entry(obj).State = EntityState.Modified;
                }
                else
                {
                    obj.Active = 1;
                    db.TaiKhoans.Add(obj);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public JsonResult Delete(int id)
        {
            TaiKhoan obj = db.TaiKhoans.Find(id);
            obj.Active = 0;
            return Json(db.SaveChanges());
        }

        public JsonResult Active(int id)
        {
            TaiKhoan obj = db.TaiKhoans.Find(id);
            obj.Active = (byte)(obj.Active != 1 ? 1 : 2);
            return Json(db.SaveChanges());
        }
    }
}
