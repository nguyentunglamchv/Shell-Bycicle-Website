using SellBicycleWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SellBicycleWebsite.Controllers
{
    public class Donhang_KHController : Controller
    {
        // GET: Donhang
        private MyDbContext db = new MyDbContext();

        // GET: Donhangs
        // Hiển thị danh sách đơn hàng
        public ActionResult Index()
        {
            //Kiểm tra đang đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            else
            {
                KhachHang kh = (KhachHang)Session["use"];
                int maND = kh.ma_KH;
                var donhangs = db.DonHangs.Include(d => d.KhachHang).Where(d => d.ma_KH == maND);
                return View(donhangs.ToList());
            }
           
        }

        // GET: Donhangs/Details/5
        //Hiển thị chi tiết đơn hàng
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.Find(id);
            var chitiet = db.CT_DonHang.Include(d => d.SanPham).Where(d => d.ma_DH == id).ToList();
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(chitiet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}