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
        DAPMEntities1 db = new DAPMEntities1();
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
    }
}