using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAPM.Controllers
{
    public class BenhController : Controller
    {
        // GET: Benh
        public ActionResult DSBenh()
        {
            return PartialView();
        }
    }
}