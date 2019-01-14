using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterViewUse.Models
{
    [MetadataType(typeof(MetadataUse))]
    public partial class Products
    {
        public class MetadataUse
        {
            [DisplayName("產品名稱")]
            public string ProductName { get; set; }           
            [DisplayName("產品單價")]
            public Nullable<decimal> UnitPrice { get; set; }
            [DisplayName("產品庫存")]
            public Nullable<short> UnitsInStock { get; set; }
        }
    }
}