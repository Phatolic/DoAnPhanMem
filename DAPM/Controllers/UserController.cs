using DAPM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DAPM.Controllers
{
    public class UserController : Controller
    {

        DAPMEntities2 db = new DAPMEntities2();
        // GET: User
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.TenKH))
                    ModelState.AddModelError(string.Empty, "Còn trống");
                if (string.IsNullOrEmpty(kh.SDT))
                    ModelState.AddModelError(string.Empty, "Còn trống");
                if (string.IsNullOrEmpty(kh.MatKhau))
                    ModelState.AddModelError(string.Empty, "Còn trống");
                if (string.IsNullOrEmpty(kh.DiaChi))
                    ModelState.AddModelError(string.Empty, "Còn trống");
                if (string.IsNullOrEmpty(kh.GioiTinh))
                    ModelState.AddModelError(string.Empty, "Còn trống");
                if (string.IsNullOrEmpty(kh.MaBHYT))
                    ModelState.AddModelError(string.Empty, "Còn trống");
                var sodienthoai = db.KHACHHANGs.FirstOrDefault(k => k.SDT == kh.SDT);
                var mabhyt = db.KHACHHANGs.FirstOrDefault(k => k.MaBHYT == kh.MaBHYT);

                if (sodienthoai != null)
                    ModelState.AddModelError(String.Empty, "Số điện thoại đã được sử dụng");
                if (mabhyt != null)
                    ModelState.AddModelError(String.Empty, "Mã BHYT đã tồn tại");
                if (ModelState.IsValid)
                {
                    db.KHACHHANGs.Add(kh);
                    db.SaveChanges();
                }
                else
                    return View();
            }
            return RedirectToAction("DangNhap");
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kh.SDT))
                    ModelState.AddModelError(string.Empty, "Số điện thoại không được để trống");
                if (string.IsNullOrEmpty(kh.MatKhau))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    var khach = db.KHACHHANGs.FirstOrDefault(k => k.SDT == kh.SDT && k.MatKhau == kh.MatKhau);
                    if (khach != null)
                    {
                        ViewBag.ThongBao = "Đã đăng nhập thành công";
                        Session["Taikhoan"] = kh;
                        Session["IsLoggedIn"] = true;
                    }
                    else
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
                }
            }
            return RedirectToAction("Index", "Home");

        }
        
        public ActionResult DangXuat()
        {
            Session.Remove("Taikhoan");
            return RedirectToAction("Index","Home");
        }
    }
}