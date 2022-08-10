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
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        public ActionResult Index()
        {
            return View();
        }
        MyDbContext db = new MyDbContext();
        public ActionResult KhachHang(string searchString, int? page)
        {
            if (Session["admin"] != null)
            {
                IOrderedQueryable<KhachHang> model = db.KhachHangs.OrderByDescending(x => x.ma_KH);
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = (IOrderedQueryable<KhachHang>)model.Where(x => x.ten_KH.Contains(searchString) || x.SDT_KH.ToString().Contains(searchString));
                }


                if (page == null) page = 1;
                int pageSize;
                if (model.Count() > 0)
                    pageSize = model.Count();
                else
                    pageSize = 5;
                int pageNumber = (page ?? 1);
                //them thuoc

                ////////////////////////////////////////

                // var sp = db.Thuocs.OrderBy(x => x.maThuoc);
                return View(model.ToPagedList(pageNumber, pageSize));


            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }
           
        }
        public int SinhMaKH()
        {
            SqlConnection connection;// = new SqlConnection(@"Data Source=LAPTOP-C73L620B\SQLEXPRESS01;Initial Catalog=QLHV;Integrated Security=True");
            SqlCommand command;
            string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table1 = new DataTable();// để truyền vào datagridview 1
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT top 1 ma_kh from khachhang order by ma_kh desc";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            int idmax;

            idmax = int.Parse(table1.Rows[0][0].ToString());
            int id = idmax + 1;
            return id;
        }
        [HttpPost]
        public ActionResult ThemKhachHang()
        {
            
            var khachhang = new KhachHang();
            khachhang.ma_KH = SinhMaKH();
            khachhang.ten_KH = Request.Form["ten_KH"];
            khachhang.SDT_KH = int.Parse(Request.Form["SDT_KH"]);
            khachhang.GioiTinh_KH = Request.Form["GioiTinh_KH"];
            khachhang.NgaySinh_KH = DateTime.Parse(Request.Form["NgaySinh_KH"]);
            khachhang.CMND_KH = int.Parse( Request.Form["CMND_KH"]);
            khachhang.DiaChi_KH = Request.Form["DiaChi_KH"];
            khachhang.username = Request.Form["username"];
            khachhang.pw = Request.Form["pw"];
            db.KhachHangs.Add(khachhang);
           
            db.SaveChanges();
            return RedirectToAction("KhachHang");
          

        }
        public ActionResult SuaKhachHang(string id)
        {
              var khachang = db.KhachHangs.Find(int.Parse(id));

                return View(khachang);
        }
        [HttpPost]
        public ActionResult SuaKhachHang(KhachHang khacHang)
        {
            
                
                    var olditem = db.KhachHangs.Find(khacHang.ma_KH);
                    olditem.ten_KH = khacHang.ten_KH;
                    olditem.GioiTinh_KH = khacHang.GioiTinh_KH;
                    olditem.SDT_KH = khacHang.SDT_KH;
                    olditem.CMND_KH = khacHang.CMND_KH;
                    olditem.NgaySinh_KH = khacHang.NgaySinh_KH;
                    olditem.DiaChi_KH = khacHang.DiaChi_KH;
            olditem.username= khacHang.username;
            olditem.pw = khacHang.pw;

            db.SaveChanges();
                    return RedirectToAction("KhachHang");
                
            
        }
        public ActionResult XoaKhachHang(string id)
        {
                var kh = db.KhachHangs.Find(int.Parse(id));
                db.KhachHangs.Remove(kh);
                db.SaveChanges();

                return RedirectToAction("KhachHang");

            
           
        }
     


        
    }
}