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
    
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.HopDongs = new HashSet<HopDong>();
        }
    
        public int IDKhachHang { get; set; }
        public string CongTy { get; set; }
        public string NguoiDaiDien { get; set; }
        public string DiaChi { get; set; }
        public string SDTCTy { get; set; }
        public string Email { get; set; }
        public Nullable<byte> Active { get; set; }
        public string MSThue { get; set; }
        public string SDTLienHe { get; set; }
        public string Logo { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> SoDichVu { get; set; }
        public Nullable<decimal> SoTien { get; set; }
        public Nullable<int> IDTienNang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }
        public virtual TiemNang TiemNang { get; set; }
    }
}
