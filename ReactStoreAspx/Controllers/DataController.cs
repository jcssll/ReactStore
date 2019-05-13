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
            //initializing an int variable
            //if the person has not signed in then -1 will be returned
            int uid = -1;
            //checking if session id is null or not
            if (Session["UserId"] != null)
                uid = Convert.ToInt32(Session["UserId"].ToString());
            return uid.ToString();
        }

        //(Third Endpoint) place order:  When user places an order the react app will send those orders in json format and talk to the server through this endpoint
        //user will post order data 
        [HttpPost]
        //this method handles all actions needed when a user submits an order
        //first get list of food items from user and user id
        public ActionResult PlaceOrder(IList<FoodItem> items, int id)
        {
            //To test I can place a try catch  also I can add a flag
            bool dbSuccess = false;
           try { 

            //Now open the database
            using (var db = new AppDbContext())
            {
                Order o = new Order();
                o.CustomerId = id;
                o.OrderDate = DateTime.Now;
                //add to the orders table
                db.Orders.Add(o);
                //save to the orders table
                db.SaveChanges();
                //as soon as I save this we are going to get an Order Id from the database and I want to save that order id
                int orderId = o.Id;
                decimal grandTotal = 0;
                //loop through the fooditems and add them to the orderdetails table
                foreach(var f in items)
                {
                    //initialize orderdetail object
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderId = orderId,
                        FoodItemId = f.Id,
                        Quantity = f.Quantity,
                        TotalPrice = f.Price * f.Quantity,
                    };
                    //add to orderdetail table
                    db.OrderDetails.Add(orderDetail);
                    //need to keep track of a running total create var grand total
                    grandTotal += orderDetail.TotalPrice;
                }

                o.TotalPaid = grandTotal;
                o.Status = 1;
                o.OrderDate = DateTime.Now;
                db.SaveChanges();
                dbSuccess = true;
            }
          }
            catch(Exception ex)
            {
                //log ex
                dbSuccess = false;
            }
            if (dbSuccess)
                return Json("success: true", JsonRequestBehavior.AllowGet);
            else
                return Json("success: false", JsonRequestBehavior.AllowGet);
        }
    }
}