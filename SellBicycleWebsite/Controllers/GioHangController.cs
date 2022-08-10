using SellBicycleWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBicycleWebsite.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        MyDbContext db = new MyDbContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMasp, string strURL)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.ma_SP == iMasp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp này đã tồn tại trong session[giohang] chưa
            GioHang sanpham = lstGioHang.Find(n => n.iMasp == iMasp);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMasp);
                //Add sản phẩm mới thêm vào list
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            //Kiểm tra masp
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.ma_SP == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMasp == iMaSP);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }
        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSP)
        {
            //Kiểm tra masp
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.ma_SP == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMasp == iMaSP);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMasp == iMaSP);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);

        }
        public ActionResult Index()
        {
            return View();
        }
        public int SinhMaDH()
        {
            SqlConnection connection;// = new SqlConnection(@"Data Source=LAPTOP-C73L620B\SQLEXPRESS01;Initial Catalog=QLHV;Integrated Security=True");
            SqlCommand command;
            string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table1 = new DataTable();// để truyền vào datagridview 1
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT top 1 ma_DH from DonHang order by ma_dh desc";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            int idmax;

            idmax = int.Parse(table1.Rows[0][0].ToString());
           int id = idmax+1;
            return id;
        }

        #region // Mới hoàn thiện
        //Xây dựng chức năng đặt hàng
        public ActionResult ThongTinDatHang()
        {
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            else
            {
               
                    List<GioHang> lstGioHang = LayGioHang();
                int sum = 0;
                foreach (var item in lstGioHang)
                {
                    CT_DonHang ctDH = new CT_DonHang();
                    decimal thanhtien = item.iSoLuong * (decimal)item.dDonGia;
                    sum = sum + (int)thanhtien;
                    
                }
                ViewBag.TongTien = TongTien();
                    return View(lstGioHang); 
                
            }
            
        }
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            if (Session["GioHang"] != null)
            {
                RedirectToAction("GioHang", "Home");
            }
            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            //KhachHang kh = (KhachHang)Session["use"];
          //  KhachHang kh = new KhachHang();
            List<GioHang> gh = LayGioHang();
            /*  ddh.ma_DH = SinhMaDH();
              ddh.diachi_giaohang = kh.DiaChi_KH;
              ddh.ma_KH = kh.ma_KH;
              ddh.hoten_nguoinhan = kh.ten_KH;
              ddh.thoigian = DateTime.Now;*/
            //   ddh.tongtien =int.Parse(TongTien().ToString());
            //đơn đạt hàng kiểu mới
            KhachHang kh = (KhachHang)Session["use"];
            ddh.ma_DH = SinhMaDH();
            ddh.ma_KH = kh.ma_KH;
            ddh.diachi_giaohang= Request.Form["diachi"];
            ddh.hoten_nguoinhan= Request.Form["ten_nguoinhan"];
            ddh.sdt_nguoinhan = int.Parse(Request.Form["sdt_nguoinhan"]);
            ddh.tongtien = int.Parse(TongTien().ToString());
            ddh.thoigian = DateTime.Now;
            ddh.trangthai = "Chờ xác nhận";
            int sum=0;
            foreach (var item in gh)
            {
                CT_DonHang ctDH = new CT_DonHang();
                decimal thanhtien = item.iSoLuong * (decimal)item.dDonGia;
                sum = sum + (int)thanhtien;
                // db.Chitietdonhangs.Add(ctDH);
            }
            //ddh.tongtien = sum;
            Console.WriteLine(ddh);
            db.DonHangs.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                CT_DonHang ctDH = new CT_DonHang();
                decimal thanhtien = item.iSoLuong * (decimal)item.dDonGia;
                ctDH.ma_DH = ddh.ma_DH;
                ctDH.ma_SP = item.iMasp;
                ctDH.soluongban = item.iSoLuong;
                ctDH.dongiaban = (int)item.dDonGia;
                ctDH.thanhtien = (int)thanhtien;
                db.CT_DonHang.Add(ctDH);
               // db.Chitietdonhangs.Add(ctDH);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("Index", "Donhang_KH");
        }
        #endregion

    }
}