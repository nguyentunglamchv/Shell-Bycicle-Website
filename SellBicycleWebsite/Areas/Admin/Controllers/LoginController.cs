using SellBicycleWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBicycleWebsite.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        MyDbContext db = new MyDbContext();
        public ActionResult NhanVienDangNhap()
        {
            return View();
        }
       // [HttpPost]
        public ActionResult NhanVien_DangNhap(FormCollection userlog)
        {
            string tendn = userlog["tendn"].ToString();
            string mk = userlog["mk"].ToString();
            
            var isAdminLogin = db.NhanVien_DN.SingleOrDefault(x => x.tendn_NV.Equals(tendn) && x.mk_NV.Equals(mk) && x.maquyen.Equals(1));          
            if (isAdminLogin != null)// admin
            {
                Session["admin"] = isAdminLogin;
                NhanVien_DN tmp = (NhanVien_DN)Session["admin"];
                NhanVien nv = db.NhanViens.Find(tmp.ma_NV);
                Session["nv"] = nv;
                return RedirectToAction("Index", "Admin");

            }
          
            else
            {
                ViewBag.Fail = "Tên đăng nhập hoặc mật khẩu sai";
                return View("NhanVienDangNhap");
            }

        }
        public ActionResult LoadTenNV()
        {
            if (Session["admin"] != null)// admin
            {

                NhanVien_DN tmp = (NhanVien_DN)Session["admin"];
                NhanVien nv = db.NhanViens.Find(tmp.ma_NV);
                Session["nv"] = nv;
                return PartialView();

            }
            else
            {
                return RedirectToAction("YeuCauDangNhap", "Login");
            }
            
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View("NhanVienDangNhap");
        }
        public ActionResult YeuCauDangNhap()
        {
            return View();
        }
    }
}