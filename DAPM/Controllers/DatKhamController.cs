using DAPM.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace DAPM.Controllers
{
    public class DatKhamController : Controller
    {
        // GET: DatKham
        DAPMEntities1 db = new DAPMEntities1();
        
        [HttpGet]
        public ActionResult LayTenBS()
        {
            
            List<string> tenBacSiList = db.BACSIs.Select(bs => bs.TenBS).ToList();
            
            
            return View(tenBacSiList);
        }
        [HttpPost]
        public ActionResult LayTenBS(LichTuVan tv, BACSI bs, KHACHHANG kh) 
        {
            if (ModelState.IsValid)
            {

                if (string.IsNullOrEmpty(tv.NgayGio?.ToString()))
                    ModelState.AddModelError(string.Empty, "Còn trống");
                if (string.IsNullOrEmpty(tv.GhiChu))
                    ModelState.AddModelError(string.Empty, "Còn trống");

                var bacsi = db.BACSIs.FirstOrDefault(s => s.TenBS == bs.TenBS);
                var ma_bs = bacsi.MaBS;
                tv.MaBS = ma_bs;

                var khach = db.KHACHHANGs.FirstOrDefault(k => k.SDT == kh.SDT);
                tv.MaKH = khach.MaKH;


                if (ModelState.IsValid)
                {
                    db.LichTuVans.Add(tv);
                    db.SaveChanges();

                }
                else
                    return View();
            }
            
            return RedirectToAction("Index","Home");
        }
    }
}