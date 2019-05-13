using ReactStoreAspx.Models;
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

        // I want to return the GetMenuList in JSON format
        //1. Declare a variable that will hold the food items
        //this is in the namespace model

        public IList<FoodItem> menuItems;
        //(First Endpoint): We need our food items so we need to get to our fooditem menu list
        // GET: Data
        [HttpGet]
        public ActionResult GetMenuList()
        {
            menuItems = new List<FoodItem>();
            using (var db = new AppDbContext())
            {
                foreach(var f in db.FoodItems)
                {
                    menuItems.Add(f);
                }
            }
            return Json(menuItems, JsonRequestBehavior.AllowGet);
        }
        //(Second Endpoint) We will need the react app to know the user id when the user signs in 
        [HttpGet]
        public string GetUserId()
        {
            return "1";
        }

        //(Third Endpoint) place order:  When user places an order the react app will send those orders in json format and talk to the server through this endpoint
        //user will post order data 
        [HttpPost]
        public ActionResult PlaceOrder()
        {
            return null;
        }
    }
}