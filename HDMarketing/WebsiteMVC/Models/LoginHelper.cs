using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteMVC.Models
{
    public class LoginHelper
    {
        public static string LOGIN = "LOGIN";

        public static int CheckLogin(string Username, string Password)
        {
            HttpContext.Current.Session.Clear();
            var acc = new HDMarketingEntities().TaiKhoans.FirstOrDefault(q => q.Username == Username && q.Password == Password);
            HttpContext.Current.Session[LOGIN] = acc;
            return acc?.Active ?? 0;
        }

        public static TaiKhoan GetAccount()
        {
            return HttpContext.Current.Session[LOGIN] as TaiKhoan;
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session[LOGIN] = null;
        }


        public static bool CheckRole(params eRole[] roles)
        {
            var acc = GetAccount();
            return acc != null && (acc.ChucVu == "ADMIN" || roles.Any(q => q.ToString() == acc.ChucVu));
        }
    }
}