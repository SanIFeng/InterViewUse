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
        public List<int> shopping_car { get; set; }
        public List<Products> product_account(List<int> account)
        { Repository<Products> RP = new Repository<Products>();
            List<Products> LP = new List<Products>();
            for(int i = 0;i<account.Count;i+=1)
            {
                LP.Add(RP.GetByID(account[i]));
            }
            return LP;
        }
    }
}