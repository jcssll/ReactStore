using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactStoreAspx.Controllers
{
    public class DataController : Controller
    {
        //Goal : Create 3 endpoints

        //1. We need our food items so we need to get to our fooditem menu list
        // GET: Data
        [HttpGet]
        public ActionResult GetMenuList()
        {
            return null;
        }
        //2. We will need the react app to know the user id when the user signs in 
        [HttpGet]
        public string GetUserId()
        {
            return "1";
        }

        //3. place order:  When user places an order the react app will send those orders in json format and talk to the server through this endpoint
        //user will post order data 
        [HttpPost]
        public ActionResult PlaceOrder()
        {
            return null;
        }
    }
}