using SellBicycleWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace SellBicycleWebsite.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        MyDbContext db = new MyDbContext();
        public ActionResult Index(string searchString, int? page, string filterString)
        {
            if (Session["admin"] != null)
            {
                IOrderedQueryable<SanPham> model = (IOrderedQueryable<SanPham>)db.SanPhams.OrderByDescending(x => x.maLoai);
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = (IOrderedQueryable<SanPham>)model.Where(x => x.ten_SP.Contains(searchString));
                }
                if (!String.IsNullOrEmpty(filterString))
                {
                    model = (IOrderedQueryable<SanPham>)model.Where(x => x.Loai_SP.tenLoai.Contains(filterString));
                }


                if (page == null) page = 1;
                int pageSize;
                if (model.Count() > 0)
                    pageSize = model.Count();
                else
                    pageSize = 5;
                int pageNumber = (page ?? 1);

                var NTselected = new SelectList(db.Loai_SP, "maLoai", "tenLoai");
                ViewBag.maLoai = NTselected;
                var MaTuselected = new SelectList(db.NCCs, "ma_NCC", "ten_NCC");
                ViewBag.ma_NCC = MaTuselected;

                // var sp = db.Thuocs.OrderBy(x => x.maThuoc);
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }
            
        }
        public ActionResult XeDapTheThao(string searchString, int? page, string filterString)
        {
           var model = db.SanPhams.Where(n => n.maLoai == 1);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = (IOrderedQueryable<SanPham>)model.Where(x=> x.ten_SP.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(filterString))
            {
                model = (IOrderedQueryable<SanPham>)model.Where(x => x.Loai_SP.tenLoai.Contains(filterString));
            }


            if (page == null) page = 1;
            int pageSize;
            if (model.Count() > 0)
                pageSize = model.Count();
            else
                pageSize = 5;
            int pageNumber = (page ?? 1);

            var NTselected = new SelectList(db.Loai_SP, "maLoai", "tenLoai");
            ViewBag.maLoai = NTselected;
            var MaTuselected = new SelectList(db.NCCs, "ma_NCC", "ten_NCC");
            ViewBag.ma_NCC = MaTuselected;
            // var sp = db.Thuocs.OrderBy(x => x.maThuoc);
            return View(model.ToList()); ;
            
        }
        public ActionResult XeDapDien(string searchString, int? page, string filterString)
        {
            var model = db.SanPhams.Where(n => n.maLoai == 4);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = (IOrderedQueryable<SanPham>)model.Where(x => x.ten_SP.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(filterString))
            {
                model = (IOrderedQueryable<SanPham>)model.Where(x => x.Loai_SP.tenLoai.Contains(filterString));
            }


            if (page == null) page = 1;
            int pageSize;
            if (model.Count() > 0)
                pageSize = model.Count();
            else
                pageSize = 5;
            int pageNumber = (page ?? 1);

            var NTselected = new SelectList(db.Loai_SP, "maLoai", "tenLoai");
            ViewBag.maLoai = NTselected;
            var MaTuselected = new SelectList(db.NCCs, "ma_NCC", "ten_NCC");
            ViewBag.ma_NCC = MaTuselected;
            // var sp = db.Thuocs.OrderBy(x => x.maThuoc);
            return View(model.ToList());
        }
        public ActionResult XeMayDien(string searchString, int? page, string filterString)
        {
            var model = db.SanPhams.Where(n => n.maLoai == 5);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = (IOrderedQueryable<SanPham>)model.Where(x => x.ten_SP.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(filterString))
            {
                model = (IOrderedQueryable<SanPham>)model.Where(x => x.Loai_SP.tenLoai.Contains(filterString));
            }


            if (page == null) page = 1;
            int pageSize;
            if (model.Count() > 0)
                pageSize = model.Count();
            else
                pageSize = 5;
            int pageNumber = (page ?? 1);
            var NTselected = new SelectList(db.Loai_SP, "maLoai", "tenLoai");
            ViewBag.maLoai = NTselected;
            var MaTuselected = new SelectList(db.NCCs, "ma_NCC", "ten_NCC");
            ViewBag.ma_NCC = MaTuselected;

            // var sp = db.Thuocs.OrderBy(x => x.maThuoc);
            return View(model.ToList());
        }
        public ActionResult PhuKien(string searchString, int? page, string filterString)
        {
            IOrderedQueryable<SanPham> model = (IOrderedQueryable<SanPham>)db.SanPhams.Where(n => n.maLoai == 6||n.maLoai==7||n.maLoai==8);
            if (!String.IsNullOrEmpty(searchString))
            {
                model = (IOrderedQueryable<SanPham>)model.Where(x => x.ten_SP.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(filterString))
            {
                model = (IOrderedQueryable<SanPham>)model.Where(x => x.Loai_SP.tenLoai.Contains(filterString));
            }


            if (page == null) page = 1;
            int pageSize;
            if (model.Count() > 0)
                pageSize = model.Count();
            else
                pageSize = 5;
            int pageNumber = (page ?? 1);


            // var sp = db.Thuocs.OrderBy(x => x.maThuoc);
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        // san pham
        //them sua xoa san pham

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images/"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }
        public int SinhMaSP()
        {
            SqlConnection connection;// = new SqlConnection(@"Data Source=LAPTOP-C73L620B\SQLEXPRESS01;Initial Catalog=QLHV;Integrated Security=True");
            SqlCommand command;
            string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table1 = new DataTable();// để truyền vào datagridview 1
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT top 1 ma_sp from sanpham order by ma_KH desc";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            int idmax;

            idmax = int.Parse(table1.Rows[0][0].ToString());
            int id = idmax + 1;
            return id;
        }
        [HttpPost]
        public ActionResult ThemSanPham(Image img, HttpPostedFileBase file)
        {
           
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                              + file.FileName);
                        img.ImagePath = file.FileName;
                    }
                }
                var sp = new SanPham();
            //sp.ma_SP = Request.Form["ma_SP"];
                sp.ma_SP = SinhMaSP();
                sp.ten_SP = Request.Form["ten_SP"];
                sp.ma_NCC = int.Parse (Request.Form["ma_NCC"]);
                sp.soluong = int.Parse(Request.Form["soluong"]);
                sp.dongiaban = int.Parse(Request.Form["dongiaban"]);
                sp.dongianhap = int.Parse(Request.Form["dongianhap"]);
                sp.thongso = Request.Form["thongso"];
                sp.maLoai = int.Parse(Request.Form["maLoai"]);
                sp.mota = Request.Form["mota"];
                sp.link_anhdaidien = file.FileName;
               
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            
           
        }
        public ActionResult SuaSanPham(int id)
        {            
                var sp=db.SanPhams.Find(id);
                return View(sp);
        }
        [HttpPost]
        public ActionResult SuaSanPham(SanPham sp)
        {
           
            var olditem = db.SanPhams.Find(sp.ma_SP);
            olditem.ten_SP = sp.ten_SP;
           olditem.ma_NCC = sp.ma_NCC;
            olditem.soluong = sp.soluong;
            olditem.khuyenmai = sp.khuyenmai;
            olditem.dongiaban = sp.dongiaban;
          olditem.dongianhap = sp.dongianhap;
            olditem.maLoai = sp.maLoai;
           olditem.mota = sp.mota;
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }
        public ActionResult XoaSanPham(int id)
        {
           
                var sp = db.SanPhams.Find(id);
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        public ActionResult ChiTietSanPham(string id)
        {           
            var sp = db.SanPhams.Find(int.Parse(id));
            return View(sp);
        }
        public ActionResult LoaiSanPham(string searchString, int? page, string filterString)
        {
            if (Session["admin"] != null)
            {
                IOrderedQueryable<Loai_SP> model = (IOrderedQueryable<Loai_SP>)db.Loai_SP.OrderByDescending(x => x.maLoai);
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = (IOrderedQueryable<Loai_SP>)model.Where(x => x.tenLoai.Contains(searchString));
                }



                if (page == null) page = 1;
                int pageSize;
                if (model.Count() > 0)
                    pageSize = model.Count();
                else
                    pageSize = 5;
                int pageNumber = (page ?? 1);


                // var sp = db.Thuocs.OrderBy(x => x.maThuoc);
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }
            
        }
        public int SinhMaLoaiSP()
        {
            SqlConnection connection;// = new SqlConnection(@"Data Source=LAPTOP-C73L620B\SQLEXPRESS01;Initial Catalog=QLHV;Integrated Security=True");
            SqlCommand command;
            string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table1 = new DataTable();// để truyền vào datagridview 1
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT top 1 maloai from loai_sp order by maloai desc";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            int idmax;

            idmax = int.Parse(table1.Rows[0][0].ToString());
            int id = idmax + 1;
            return id;
        }
        [HttpPost]
        public ActionResult ThemLoaiSanPham()
        {

            
            var loai = new Loai_SP();
            //sp.ma_SP = Request.Form["ma_SP"];
            loai.maLoai = SinhMaLoaiSP();
            loai.tenLoai = Request.Form["tenLoai"];
            db.Loai_SP.Add(loai);
            db.SaveChanges();
            return RedirectToAction("LoaiSanPham");


        }
        public ActionResult SuaLoaiSanPham(string id)
        {
            
                var loaisp = db.Loai_SP.Find(int.Parse(id));

                return View(loaisp);


        }
        [HttpPost]
        public ActionResult SuaLoaiSanPham(Loai_SP loaisp)
        {
           
                    var olditem = db.Loai_SP.Find(loaisp.maLoai);
                    olditem.tenLoai =loaisp.tenLoai;
                    db.SaveChanges();
                    return RedirectToAction("LoaiSanPham");
              
        }
        public ActionResult XoaLoaiSanPham(string id)
        {
            
                var loaisp = db.Loai_SP.Find(int.Parse(id));
                db.Loai_SP.Remove(loaisp);
                db.SaveChanges();
                return RedirectToAction("LoaiSanPham");
            

        }
        public ActionResult NCC(string searchString, int? page, string filterString)
        {
            if (Session["admin"] != null)
            {
                IOrderedQueryable<NCC> model = (IOrderedQueryable<NCC>)db.NCCs.OrderByDescending(x => x.ma_NCC);
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = (IOrderedQueryable<NCC>)model.Where(x => x.ten_NCC.Contains(searchString));
                }
                if (page == null) page = 1;
                int pageSize;
                if (model.Count() > 0)
                    pageSize = model.Count();
                else
                    pageSize = 5;
                int pageNumber = (page ?? 1);


                // var sp = db.Thuocs.OrderBy(x => x.maThuoc);
                return View(model.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }

            
        }
        public int SinhMaNCC()
        {
            SqlConnection connection;// = new SqlConnection(@"Data Source=LAPTOP-C73L620B\SQLEXPRESS01;Initial Catalog=QLHV;Integrated Security=True");
            SqlCommand command;
            string str = @"Data Source=LAPTOP-OLF1LQUT;Initial Catalog=SellBicycleWebsite;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table1 = new DataTable();// để truyền vào datagridview 1
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "SELECT top 1 ma_NCC from NCC order by ma_NCC desc";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            int idmax;

            idmax = int.Parse(table1.Rows[0][0].ToString());
            int id = idmax + 1;
            return id;
        }
        [HttpPost]
        public ActionResult ThemNCC()
        {


            var ncc = new NCC();
            //sp.ma_SP = Request.Form["ma_SP"];
            ncc.ma_NCC= SinhMaNCC();
            ncc.ten_NCC = Request.Form["ten_NCC"];
            ncc.diachi_NCC = Request.Form["diachi_NCC"];
            ncc.std_NCC = int.Parse(Request.Form["std_NCC"]);
            ncc.email_NCC = Request.Form["email_NCC"];
            db.NCCs.Add(ncc);
            db.SaveChanges();
            return RedirectToAction("NCC");


        }
        public ActionResult SuaNCC(string id)
        {

            var ncc = db.NCCs.Find(int.Parse(id));

            return View(ncc);


        }
        [HttpPost]
        public ActionResult SuaNCC(NCC ncc)
        {

            var olditem = db.NCCs.Find(ncc.ma_NCC);
            olditem.ten_NCC = ncc.ten_NCC;
            olditem.diachi_NCC = ncc.diachi_NCC;
            olditem.std_NCC = ncc.std_NCC;
            olditem.email_NCC = ncc.email_NCC;
            db.SaveChanges();
            return RedirectToAction("NCC");

        }
        public ActionResult XoaNCC(string id)
        {

            var ncc = db.NCCs.Find(int.Parse(id));
            db.NCCs.Remove(ncc);
            db.SaveChanges();
            return RedirectToAction("NCC");


        }
    }
}