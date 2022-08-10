using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellBicycleWebsite.Models;
namespace SellBicycleWebsite.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TKDoanhThu()
        {
            if (Session["admin"] != null)
            {
                SqlConnection connection;
                SqlCommand command;
                string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table1 = new DataTable();
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "select day(hoadonban.ngaylap_hoadon)as 'ngay',month(hoadonban.ngaylap_hoadon) as'thang',year(hoadonban.ngaylap_hoadon)as 'nam',sum(HoaDonBan.tongtien) as'doanhthu' from HoaDonBan group by day(hoadonban.ngaylap_hoadon),month(hoadonban.ngaylap_hoadon),year(hoadonban.ngaylap_hoadon)";
                adapter.SelectCommand = command;
                table1.Clear();
                adapter.Fill(table1);
                List<DoanhThu> ds = new List<DoanhThu>();
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    DoanhThu kq = new DoanhThu();

                    kq.ngay = int.Parse(table1.Rows[i]["ngay"].ToString());
                    kq.thang = int.Parse(table1.Rows[i]["thang"].ToString());
                    kq.nam = int.Parse(table1.Rows[i]["nam"].ToString());
                    kq.doanhthu = int.Parse(table1.Rows[i]["doanhthu"].ToString());
                    ds.Add(kq);
                }
                ViewBag.MyList = ds;

                return View();

            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }
           
        }
        public ActionResult TKSoDonHang()
        {
            if (Session["admin"] != null)
            {
                SqlConnection connection;
                SqlCommand command;
                string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table1 = new DataTable();
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = " select day(donhang.thoigian)as 'ngay',month(donhang.thoigian) as'thang',year(donhang.thoigian)as 'nam',count(donhang.ma_DH) as'sodonhang' from DonHang group by day(donhang.thoigian),month(donhang.thoigian),year(donhang.thoigian)";
                adapter.SelectCommand = command;
                table1.Clear();
                adapter.Fill(table1);
                List<TKDonHang> ds = new List<TKDonHang>();
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    TKDonHang kq = new TKDonHang();
                    kq.ngay = int.Parse(table1.Rows[i]["ngay"].ToString());
                    kq.thang = int.Parse(table1.Rows[i]["thang"].ToString());
                    kq.nam = int.Parse(table1.Rows[i]["nam"].ToString());
                    kq.sodonhang = int.Parse(table1.Rows[i]["sodonhang"].ToString());
                    ds.Add(kq);
                }
                ViewBag.MyList = ds;

                return View();
            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }
           
        }
        public ActionResult TKSanPhamBanChay()
        {
            if (Session["admin"] != null)
            {
                SqlConnection connection;
                SqlCommand command;
                string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table1 = new DataTable();
                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "Select Top 5 SanPham.ten_SP, SUM(CT_DonHang.soluongban) as Tongsoluong from SanPham, CT_DonHang where SanPham.ma_SP = CT_DonHang.ma_SP group by SanPham.ten_SP order by Tongsoluong desc";
                adapter.SelectCommand = command;
                table1.Clear();
                adapter.Fill(table1);
                List<SPBanChay> ds = new List<SPBanChay>();
                for (int i = 0; i < table1.Rows.Count; i++)
                {
                    SPBanChay kq = new SPBanChay();
                    kq.tensp = table1.Rows[i]["ten_SP"].ToString();
                    kq.soluongban = int.Parse(table1.Rows[i]["Tongsoluong"].ToString());
                    ds.Add(kq);
                }
                ViewBag.MyList = ds;

                return View();
            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }
         
            
        }
    }
}