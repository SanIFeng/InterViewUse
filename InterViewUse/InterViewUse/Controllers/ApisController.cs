using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InterViewUse.Models;

namespace InterViewUse.Controllers
{
    public class ApisController : ApiController
    { Repository<Shippers> shippers = new Repository<Shippers>();
        public IEnumerable<Shippers> GetAll()
        {
            return shippers.GetAll();
        }
        public IHttpActionResult PostNewone(Shippers sh)
        {
            if (sh != null)
            {
                shippers.Create(sh);
                return Json<string>("新增成功");
            }
            else
            {
               return Json<string>("新增失敗");
            }
            
        }
    }
}
