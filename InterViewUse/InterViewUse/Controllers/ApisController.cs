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
            if (!ModelState.IsValid)//發生綁定前值為null，判斷值是否為有效
            {
                return BadRequest(ModelState);//回傳代碼400(值無效)
            }
            else
            {   shippers.Create(sh);
                return StatusCode(HttpStatusCode.Created);//回傳值為201
            }
            
        }
    }
}
