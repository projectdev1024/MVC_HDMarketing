using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteMVC.Models
{
    public class BaoCaoThanhToan
    {
        public DateTime Time { get; set; }
        public decimal SoTien { get; set; }
        public int SoHopDong { get; set; }
        public string LinkDetalt { get; set; }
    }
}