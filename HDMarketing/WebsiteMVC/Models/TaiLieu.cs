//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaiLieu
    {
        public int IDTaiLieu { get; set; }
        public string TenTaiLieu { get; set; }
        public Nullable<int> IDHopDong { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<int> NguoiTao { get; set; }
        public string MoTa { get; set; }
        public string File { get; set; }
    
        public virtual HopDong HopDong { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
