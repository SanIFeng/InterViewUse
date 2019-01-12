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
        //===================================新增=========================================
        [HttpGet]
        public ActionResult CreateNewOne_partial()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateNewOne_partial(string CompanyName, string Phone)
        {
            if (CompanyName != null && Phone != null)
            {
                Shippers sp = new Shippers() { CompanyName = CompanyName, Phone = Phone };
                shippers.Create(sp);                
            }
            return RedirectToAction("Index");
        }
        //==================================修改=============================================
        [HttpGet]
        public ActionResult AlterShip_partial(int id)
        {           
            return PartialView(shippers.GetByID(id));
        }
        [HttpPost]
        public ActionResult AlterShip_partial(Shippers sh)
        {
            if(sh!=null)
            {
                shippers.Update(sh);
            }           
            return RedirectToAction("Index");
        }
    }
}