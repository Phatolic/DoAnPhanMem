using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAPM.Models;

namespace DAPM.Controllers
{
    public class BacSiController : Controller
    {
        // GET: BacSi
        DAPMEntities db = new DAPMEntities();
        private List<BACSI> LayDSBacsi()
        {
            var dsBacsi = db.BACSIs.Include(bacsi => bacsi.CHUYENKHOA)
                           .OrderByDescending(bacsi => bacsi.TenBS)
                           .ToList();

            return dsBacsi;
        }

        public ActionResult DSBacsi()
        {
            List<BACSI> dsBacsi = LayDSBacsi();

            return PartialView(dsBacsi);
        }

        public ActionResult TimKiem(string tenBacSi)
        {
            // Thực hiện tìm kiếm sản phẩm theo tên trong cơ sở dữ liệu
            var danhSachBacSi = db.BACSIs.Where(s => s.TenBS.Contains(tenBacSi)).ToList();

            // Trả về view kết quả tìm kiếm với danh sách sản phẩm
            return View("DSBacsi", danhSachBacSi);
        }
        public ActionResult KetQuaTimKiem(List<BACSI> danhSachBacSi)
        {
            return View();
        }
    }
}