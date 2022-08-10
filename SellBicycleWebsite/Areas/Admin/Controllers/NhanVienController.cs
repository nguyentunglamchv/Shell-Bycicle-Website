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
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien
        MyDbContext db = new MyDbContext();
        public ActionResult NhanVien()
        {
            return View();
        }
       public ActionResult QLNhanVien(string searchString, int? page)
        {
            if (Session["admin"] != null)
            {
                IOrderedQueryable<NhanVien> model = db.NhanViens.OrderByDescending(x => x.ma_NV);
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = (IOrderedQueryable<NhanVien>)model.Where(x => x.ten_NV.Contains(searchString) || x.sdt_NV.ToString().Contains(searchString));
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
        public int SinhMaNV()
        {
            SqlConnection connection;// = new SqlConnection(@"Data Source=LAPTOP-C73L620B\SQLEXPRESS01;Initial Catalog=QLHV;Integrated Security=True");
            SqlCommand command;
            string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table1 = new DataTable();// để truyền vào datagridview 1
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT top 1 ma_nv from nhanvien order by ma_nv desc";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            int idmax;

            idmax = int.Parse(table1.Rows[0][0].ToString());
            int id = idmax + 1;
            return id;
        }
        [HttpPost]
        public ActionResult ThemNhanVien()
        {

            var khachhang = new NhanVien();
            khachhang.ma_NV = SinhMaNV();
            khachhang.ten_NV = Request.Form["ten_NV"];
            khachhang.ngaysinh_NV = DateTime.Parse( Request.Form["ngaysinh_NV"]);

            khachhang.ma_DV = int.Parse(Request.Form["ma_DV"]);
            khachhang.email_NV = Request.Form["email_NV"];
            khachhang.sdt_NV =int.Parse(Request.Form["sdt_NV"]);
            khachhang.diachi_NV = Request.Form["diachi_NV"];
            khachhang.chuvu = Request.Form["chuvu"];
            khachhang.batdau = DateTime.Now;
            
            db.NhanViens.Add(khachhang);

            db.SaveChanges();
            return RedirectToAction("QLNhanVien");


        }
        public ActionResult SuaNhanVien(string id)
        {
            var khachang = db.NhanViens.Find(int.Parse(id));

            return View(khachang);
        }
        [HttpPost]
        public ActionResult SuaNhanVien(NhanVien nv)
        {


            var olditem = db.NhanViens.Find(nv.ma_NV);
            olditem.ten_NV = nv.ten_NV;
            olditem.ngaysinh_NV = nv.ngaysinh_NV;
            olditem.email_NV = nv.email_NV;
            olditem.sdt_NV = nv.sdt_NV;
            olditem.diachi_NV = nv.diachi_NV;
            olditem.chuvu = nv.chuvu;
          
            db.SaveChanges();
            return RedirectToAction("QLNhanVien");


        }
        public ActionResult ChiTietNhanVien(string id)
        {
            var sp = db.NhanViens.Find(int.Parse(id));
            return View(sp);
        }
        public ActionResult XoaNhanVien(string id)
        {
            var kh = db.NhanViens.Find(int.Parse(id));
            db.NhanViens.Remove(kh);
            db.SaveChanges();

            return RedirectToAction("QLNhanVien");

        }
        public ActionResult TaiKhoan_NhanVien(int id)
        {
            var sp = db.NhanVien_DN.Where(x=>x.ma_NV==id);
            return View(sp.ToList());
        }
        [HttpPost]
        public ActionResult ThemTaiKhoan()
        {

            var tk = new NhanVien_DN();
            tk.ma_NV = int.Parse(Request.Form["ma_NV"]);
            tk.tendn_NV = Request.Form["tendn_NV"];
            tk.mk_NV = Request.Form["mk_NV"];
            tk.maquyen = int.Parse(Request.Form["maquyen"]);
            db.NhanVien_DN.Add(tk);

            db.SaveChanges();
            return RedirectToAction("TaiKhoan_NhanVien");


        }
        public ActionResult SuaTaiKhoan(string id,string tendn)
        {
            var khachang = db.NhanVien_DN.Find(int.Parse(id),tendn);

            return View(khachang);
        }
        [HttpPost]
        public ActionResult SuaTaiKhoan(NhanVien_DN nv)
        {


            var olditem = db.NhanVien_DN.Find(nv.ma_NV,nv.tendn_NV);
            olditem.mk_NV = nv.mk_NV;
            olditem.maquyen = nv.maquyen;
           

            db.SaveChanges();
            return RedirectToAction("TaiKhoan_NhanVien");


        }
       
        public ActionResult XoaNhanVien(string id,string tendn)
        {
            var kh = db.NhanVien_DN.Find(int.Parse(id),tendn);
            db.NhanVien_DN.Remove(kh);
            db.SaveChanges();

            return RedirectToAction("TaiKhoan_NhanVien");

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}