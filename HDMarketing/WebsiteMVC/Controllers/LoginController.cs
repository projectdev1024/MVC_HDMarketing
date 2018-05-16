using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: AdminCP/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var active = Models.LoginHelper.CheckLogin(username, password);
            if (active == 1)
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
            if (active == 0) ModelState.AddModelError("", "Đăng nhập thất bại");
            if (active == 2) ModelState.AddModelError("", "Tài khoản đã bị khóa");
            return View();
        }

        public ActionResult Logout()
        {
            Models.LoginHelper.Logout();
            return RedirectToAction("Index");
        }
    }
}