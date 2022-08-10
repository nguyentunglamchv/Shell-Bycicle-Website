using SellBicycleWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBicycleWebsite.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        MyDbContext db = new MyDbContext();
        public ActionResult XeDapTheThao()// hiển thị toanf bo xe đạp thể thao
        {
            var item = db.SanPhams.Where(n => n.maLoai == 1).ToList();
            
            return View(item);
        }
        public ActionResult TopXeDapTheThao()// hiển top5 xe đạp thể thao
        {
            var item = db.SanPhams.Where(n => n.maLoai == 1).Take(4).ToList();
            return PartialView(item);
        }
        public ActionResult XeDapThoiTrang()// hiển thị toanf bo xe đạp thoi trang
        {
            var item = db.SanPhams.Where(n => n.maLoai == 2).ToList();
            return PartialView(item);
        }
        public ActionResult TopXeDapThoiTrang()// hiển top5 xe đạp thoi trang
        {
            var item = db.SanPhams.Where(n => n.maLoai == 2).Take(4).ToList();
            return PartialView(item);
        }
        public ActionResult XeDapTreEm()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 3).ToList();
            return PartialView(item);
        }
        public ActionResult TopXeDapTreEm()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 3).Take(4).ToList();
            return PartialView(item);
        }
        public ActionResult XeDapDien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 4).ToList();
            return View(item);
        }
        public ActionResult TopXeDapDien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 4).Take(4).ToList();
            return PartialView(item);
        }
        public ActionResult XeMayDien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 5).ToList();
            return View(item);
        }
        public ActionResult PhuKien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 6|| n.maLoai == 7|| n.maLoai == 8).ToList();
            return View(item);
        }
        public ActionResult TopPhuKien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 6 || n.maLoai == 7 || n.maLoai == 8).Take(4).ToList();
            return PartialView(item);
        }
        public ActionResult TopXeMayDien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 5).Take(4).ToList();
            return PartialView(item);
        }
        public ActionResult PhuKienXeDap()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 6).ToList();
            return PartialView(item);
        }
        public ActionResult TopPhuKienXeDap()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 6).Take(4).ToList();
            return PartialView(item);
        }
        public ActionResult PhuKienXeDapDien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 6).ToList();
            return PartialView(item);
        }
        public ActionResult TopPhuKienXeDapDien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 6||n.maLoai==7).Take(4).ToList();
            return PartialView(item);
        }
        public ActionResult PhuKienXeMayDien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 8).ToList();
            return PartialView(item);
        }
        public ActionResult TopPhuKienXeMayDien()
        {
            var item = db.SanPhams.Where(n => n.maLoai == 6 || n.maLoai == 7).Take(4).ToList();
            return PartialView(item);
        }
        public ActionResult BanChay()// top nhuwngx san pham ban chay
        {
            return View();
        }
        public ActionResult MoiNhat()// top nhung san pham moi nhap
        {
            return View();
        }
        public ActionResult xemchitiet(int Masp = 0)
        {
            var chitiet = db.SanPhams.SingleOrDefault(n => n.ma_SP == Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.list_anh = db.Anh_SP.Where(n => n.ma_SP == Masp).ToList();
            return View(chitiet);
        }
    }
}