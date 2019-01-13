using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterViewUse.Models
{
    public class ShopUse
    {
        public IEnumerable<Categories> categories { get; set; }
        public IEnumerable<Products> products { get; set; }
    }
}