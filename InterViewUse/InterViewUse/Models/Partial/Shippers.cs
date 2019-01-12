using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterViewUse.Models
{
    [MetadataType(typeof(MatadataUse))]
    public partial class Shippers
    {
        public class MatadataUse
        {   [DisplayName("運輸公司編號")]
            public int ShipperID { get; set; }
            [DisplayName("運輸公司名稱")]
            public string CompanyName { get; set; }
            [DisplayName("運輸公司電話")]
            public string Phone { get; set; }
        }
    }
}