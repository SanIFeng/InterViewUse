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
    }
}
