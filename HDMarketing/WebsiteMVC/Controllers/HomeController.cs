using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteMVC.Models;

namespace WebsiteMVC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(string sfromDate, string stoDate)
        {
            var fromDate = sfromDate.ToDate();
            var toDate = stoDate.ToDate();
            if (string.IsNullOrWhiteSpace(sfromDate))
            {
                fromDate = toDate.AddMonths(-3);
            }
            fromDate = new DateTime(fromDate.Year, fromDate.Month, 1);
            toDate = new DateTime(toDate.Year, toDate.Month, DateTime.DaysInMonth(toDate.Year, toDate.Month));

            var thanhToan = db.ThanhToans.Where(q => q.NgayTT >= fromDate && q.NgayTT <= toDate).ToList();
            var data = (from d in thanhToan
                        group d by new DateTime(d.NgayTT.Value.Year, d.NgayTT.Value.Month, 1) into g
                        orderby g.Key
                        select new BaoCaoThanhToan
                        {
                            SoTien = g.Sum(q => q.SoTien) ?? 0,
                            Time = g.Key,
                            SoHopDong = g.GroupBy(q => q.IDHopDong).Count(),
                            LinkDetalt = Server.UrlDecode(Url.Action("Index", "HopDong", new { sfromDate = g.Key.ToString("yyyy-MM-dd"), stoDate = new DateTime(g.Key.Year, g.Key.Month, DateTime.DaysInMonth(g.Key.Year, g.Key.Month)).ToString("yyyy-MM-dd") }))
                        }).ToList();
            return Json(new
            {
                data,
                fromDate = fromDate.ToString("yyyy-MM-dd"),
                toDate = toDate.ToString("yyyy-MM-dd")
            });
        }
    }
}