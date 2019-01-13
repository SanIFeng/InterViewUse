using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterViewUse.Models;

namespace InterViewUse.Controllers
{
    public class ShopController : Controller
    {
        Repository<Categories> categories = new Repository<Categories>();
        Repository<Products> products = new Repository<Products>();
        ShopUse shopuse = new ShopUse();
        // GET: Shop
        public ActionResult Index(int id = 0)
        {
            shopuse.categories = categories.GetAll();
            if (id == 0)
            {
                TempData["change"] = 0;
                shopuse.products = products.GetAll();
                return View(shopuse);
            }
            else
            {
                TempData["change"] = id;
                shopuse.products = products.GetAll().Where(p => p.CategoryID == id).Select(p => p);
                return View(shopuse);
            }

        }
        public FileContentResult GetImage(int id)
        {
            var findimage = categories.GetByID(id);
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                byte[] getimages = findimage.Picture;
                ms.Write(getimages, 78, getimages.Length - 78);
                return File(ms.ToArray(), "image/png");
            }
        }
    }
}