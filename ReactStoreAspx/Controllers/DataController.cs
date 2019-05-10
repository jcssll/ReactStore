using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactStoreAspx.Controllers
{
    public class DataController : Controller
    {

        //Creating 3 endpoints
        // GET: Data
        [HttpGet]
        public ActionResult GetMenuList()
        {
            return null;
        }

        [HttpGet]
        public string GetUserId()
        {
            return "1";
        }

        //place order: when someone places an order react app will talk to the server in json format
        [HttpPost]
        public ActionResult PlaceOrder()
        {
            return null;
        }
    }
}