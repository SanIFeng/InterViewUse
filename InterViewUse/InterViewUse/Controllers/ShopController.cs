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
        // GET: Shop
        //=================================商城首頁===============================================
        public ActionResult Index(int id = 0)
        {
            ShopUse shopuse = new ShopUse();
            shopuse.categories = categories.GetAll();
            if (id == 0)
            {
                TempData["change"] = 0;
                if(Session["shopping_car"] != null)
                {
                   shopuse.shopping_car = Session["shopping_car"] as List<int>;
                }               
                shopuse.products = products.GetAll();
                return View(shopuse);
            }
            else
            {
                TempData["change"] = id;
                if (Session["shopping_car"] != null)
                {
                    shopuse.shopping_car = Session["shopping_car"] as List<int>;
                }
                shopuse.products = products.GetAll().Where(p => p.CategoryID == id).Select(p => p);
                return View(shopuse);
            }

        }
        //=================================讀取資料庫圖片用=============================================
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
        //=========================================購物車結帳頁面=========================================
        public ActionResult Accounting(int id=0)
        {  if (id == 0)
            {
                ShopUse shopuse = new ShopUse();
                shopuse.shopping_car = Session["shopping_car"] as List<int>;
                if (Session["shopping_car"] != null)
                {
                    shopuse.products = shopuse.product_account(Session["shopping_car"] as List<int>);
                }
                return View(shopuse);
            }
            else
            {
                Session["shopping_car"] = null;
                return RedirectToAction("Index", "Shop", null);
            }
        }
        public ActionResult Getsession(List<int> id)
        {
            Session["shopping_car"] = id;
            return new EmptyResult();
        }
    }
}