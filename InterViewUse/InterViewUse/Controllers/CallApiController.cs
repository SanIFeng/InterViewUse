using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterViewUse.Controllers
{
    public class CallApiController : Controller
    {
        // GET: CallApi
        public ActionResult Index()
        {
            if (Session["shopping_car"] != null)
            {
                ViewBag.car = ((List<int>)Session["shopping_car"]).Count;
            }
            return View();
        }
    }
}