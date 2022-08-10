using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellBicycleWebsite.Models
{
    public class GioHang
    {
       MyDbContext db = new MyDbContext();
        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public int km { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia - iSoLuong * dDonGia*km/100; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int Masp)
        {
            iMasp = Masp;
            SanPham sp = db.SanPhams.Single(n => n.ma_SP == iMasp);
            sTensp = sp.ten_SP;
            sAnhBia = sp.link_anhdaidien;
            dDonGia = double.Parse(sp.dongiaban.ToString());
            iSoLuong = 1;
            km = int.Parse(sp.khuyenmai.ToString());
        }
    }
}