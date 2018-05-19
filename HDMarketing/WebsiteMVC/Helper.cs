using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebsiteMVC
{
    public static class Helper
    {
        public static MvcHtmlString Required(this MvcHtmlString control)
        {
            return MvcHtmlString.Create(control.ToHtmlString().Replace("/>", " required />"));
        }

        public static MvcHtmlString Type(this MvcHtmlString control, htmlType type)
        {
            return MvcHtmlString.Create(control.ToHtmlString().Replace("type=\"text\"", $"type=\"{type.ToString().Replace("_", "-")}\""));
        }

        public static MvcHtmlString DateFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var model = htmlHelper.ViewData.Model;
            string Value = "" + (model.GetType().GetProperty(expression.GetPropertyName()).GetValue(model) as DateTime?)?.ToString("yyyy-MM-dd");
            return htmlHelper.TextBoxFor(expression, new { @class = "form-control", type = "date", Value });
        }

        public static MvcForm BeginFormMultipart(this HtmlHelper helper)
        {
            string controllerName = helper.ViewContext.RouteData.Values["controller"].ToString();
            string actionName = helper.ViewContext.RouteData.Values["action"].ToString();
            return helper.BeginForm(actionName: actionName, controllerName: controllerName, method: FormMethod.Post, htmlAttributes: new { enctype = "multipart/form-data" });
        }

        public static MvcHtmlString DropDownListForRequired<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return htmlHelper.DropDownListFor(expression, selectList, "--Vui lòng chọn--", new { @class = "form-control", required = "true" });
        }

        public static string Display(this object value, string format = "#,###")
        {
            return string.Format("{0:" + format + "}", value);
        }
    }

    public enum htmlType
    {
        date, number, radio, checkbox, color, email, file, range, reset, text, password, datetime_local
    }

    public static class ObjectExtentions
    {
        public static string GetPropertyName<T, Y>(this Expression<Func<T, Y>> expression)
        {
            if (expression.Body is MemberExpression member)
                return member.Member.Name;
            return ((expression.Body as UnaryExpression).Operand as MemberExpression).Member.Name;
        }

        public static DateTime ToDate(this string sdate, string format = "yyyy-MM-dd")
        {
            DateTime date = DateTime.Now;
            if (DateTime.TryParseExact(sdate, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out date)) return date;
            return DateTime.Now;
        }

        public static string Display<T>(this T value, string format = "#,###")
        {
            return string.Format("{0:" + format + "}", value);
        }
    }

    public static class UploadFile
    {
        public static string Save(this HttpPostedFile file, string folder = "/Content/Upload")
        {
            try
            {
                if (file == null || file.ContentLength <= 0) return null;

                string mfolder = HttpContext.Current.Server.MapPath(folder);
                if (Directory.Exists(mfolder) == false) Directory.CreateDirectory(mfolder);

                string filename = $"{DateTime.Now.ToString("ddMMyyyyhhmmss")}_{Path.GetFileName(file.FileName)}";

                file.SaveAs(Path.Combine(mfolder, filename));

                return Path.Combine(folder, filename);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SaveFor<T, Y>(this T obj, Expression<Func<T, Y>> expression, string folder = "/Content/Upload")
        {
            string name = expression.GetPropertyName();
            HttpPostedFile fileBase = HttpContext.Current.Request.Files[name];
            var s = fileBase.Save();
            if (s != null)
            {
                var property = obj.GetType().GetProperties().FirstOrDefault(q => q.Name == name);
                string old = HttpContext.Current.Server.MapPath(property?.GetValue(obj) + "");
                if (File.Exists(old)) File.Delete(old);
                property?.SetValue(obj, s);
            }
        }
    }
}