using PagedList;
using SellBicycleWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellBicycleWebsite.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: Admin/HoaDon
        MyDbContext db = new MyDbContext();
        public ActionResult HoaDon(string searchString, int? page, string filterString)
        {
            if (Session["admin"] != null)
            {
                IOrderedQueryable<HoaDonBan> model = db.HoaDonBans.OrderByDescending(x => x.maHD_ban);
                if (!String.IsNullOrEmpty(searchString))
                {
                    model = (IOrderedQueryable<HoaDonBan>)model.Where(x => x.maHD_ban.ToString().Contains(searchString) || x.ma_DH.ToString().Contains(searchString));
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
    }
}