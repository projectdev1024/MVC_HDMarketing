using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMVC.Models;

namespace WebsiteMVC.Controllers
{
    public class BaseController : Controller
    {
        public HDMarketingEntities db = new HDMarketingEntities();

        public TaiKhoan Account { get; protected set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Account = Models.LoginHelper.GetAccount();
            if (Account == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                {
                    Controller = "Login",
                    Action = "Index",
                    Area = ""
                }));
            }
            base.OnActionExecuting(filterContext);
        }

        public ActionResult NotPermistion()
        {
            return View();
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


    public class RoleAcceptAttribute : ActionFilterAttribute
    {
        public RoleAcceptAttribute(params eRole[] roles)
        {
            this.Roles = roles;
        }

        public eRole[] Roles { get; protected set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Roles.Length > 0 && filterContext.Controller is BaseController controlerBase)
            {
                if (controlerBase.Account.ChucVu != "ADMIN" && Roles.Any(q => q.ToString() == controlerBase.Account.ChucVu) == false)
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                    {
                        Controller = "Base",
                        Action = "NotPermistion",
                        Area = ""
                    }));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }

}