using PagedList;
using SellBicycleWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBicycleWebsite.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        MyDbContext db = new MyDbContext();
        public ActionResult DonHang()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }
            
        }
        public ActionResult DonHangChuaXuLy_Partial()
        {

            //var item = db.DonHangs.Where(n => n.ma_NV == null).ToList();
            var it = db.DonHangs.Where(n => n.ma_NV == null).OrderByDescending(x => x.thoigian);
            return PartialView(it);
        }
        public ActionResult DonHangDaXuLy_Partial()
        {
           // var item = db.DonHangs.Where(n => n.ma_NV != null).ToList();
            var it = db.DonHangs.Where(n => n.ma_NV != null).OrderByDescending(x => x.thoigian);
            return PartialView(it);
            
        }
        public int Get_SLSP(int id)//lay so luong san pham
        {
            var sp = db.SanPhams.Find(id);
            int soluongton = int.Parse(sp.soluong.ToString());
            return soluongton;
        }
        public int KiemTra_DonHang(int id)
        {
            return 0;
        }
        public ActionResult DuyetDonHang(int id)// duyet don hang tao luon hoa don cho don hang do
        {//phai kiem tra xem co du so luong san pham ko

            var item = db.DonHangs.Find(id);
            if(Session["admin"]!=null)
            {
                NhanVien_DN nv = (NhanVien_DN)Session["admin"];
                item.ma_NV = nv.ma_NV;
                item.trangthai = "Đặt hàng thành công!";
                db.SaveChanges();
                TaoHoaDon(item.ma_DH);
            }
            else {
                item.ma_NV = 1;
                db.SaveChanges();
                TaoHoaDon(item.ma_DH);
                   }
            return RedirectToAction("DonHang");

        }
        public int SinhMaHoaDon()
        {
            SqlConnection connection;// = new SqlConnection(@"Data Source=LAPTOP-C73L620B\SQLEXPRESS01;Initial Catalog=QLHV;Integrated Security=True");
            SqlCommand command;
            string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table1 = new DataTable();// để truyền vào datagridview 1
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT top 1 maHD_ban from HoaDonBan order by maHD_ban desc";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            int idmax;

            idmax = int.Parse(table1.Rows[0][0].ToString());
            int id = idmax + 1;
            return id;
        }
        public void TaoHoaDon(int id)
        {
            var item = db.DonHangs.Find(id);
            HoaDonBan hd = new HoaDonBan();
            hd.maHD_ban = SinhMaHoaDon();
            hd.ngaylap_hoadon = DateTime.Now;
            hd.ma_DH = item.ma_DH;
            hd.ma_NV = item.ma_NV;
            hd.tongtien = item.tongtien;
            db.HoaDonBans.Add(hd);
            db.SaveChanges();
            

        }
        public ActionResult SuaDonHang(int id)
        {
            var it = db.DonHangs.Find(id);
            return View();

        }
        [HttpPost]
        public ActionResult SuaDonHang(DonHang dh)
        {
            var oldItem = db.DonHangs.Find(dh.ma_DH);
            oldItem.ma_NV = dh.ma_NV;
            oldItem.ma_KH = dh.ma_KH;
            oldItem.thoigian = dh.thoigian;
            oldItem.tongtien = dh.tongtien;
            oldItem.diachi_giaohang = dh.diachi_giaohang;
            oldItem.sdt_nguoinhan = dh.sdt_nguoinhan;
            oldItem.hoten_nguoinhan= dh.hoten_nguoinhan;
           
            // lưu lại
            db.SaveChanges();
            // xong chuyển qua index
            return RedirectToAction("DonHang");

        }
        public ActionResult XoaDonHang(int id)
        {
            var item = db.DonHangs.Find(id);
            db.DonHangs.Remove(item);
            db.SaveChanges();
            return RedirectToAction("DonHang");

        }
        public ActionResult ChiTietDonHang(int id)
        {
            var model = db.CT_DonHang.Where(a=>a.ma_DH==id).ToList();
            

            return View(model);

        }
        

    }
}