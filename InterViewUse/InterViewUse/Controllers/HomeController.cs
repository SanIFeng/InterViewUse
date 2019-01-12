using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterViewUse.Models;

namespace InterViewUse.Controllers
{
    public class HomeController : Controller
    {
        Repository<Shippers> shippers = new Repository<Shippers>();
        // GET: Home
        public ActionResult Index()
        {
            return View(shippers.GetAll());
        }
    }
}