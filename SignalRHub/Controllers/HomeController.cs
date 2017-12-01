using SignalRHub.Services;
using SignalRHub.Hubs;
using SignalRHub.Models;
using SignalRHub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRHub.Controllers
{
    public class HomeController : Controller
    {
        private CustomerService objCust;
        //CustomerRepository CustRepository;
        public HomeController()
        {
            this.objCust = new CustomerService();
        }

        [HttpGet]
        public ActionResult GetAllData()
        {
            int Count = 10; IEnumerable<object> Result = null;
            try
            {
                object[] parameters = { Count };
                Result = objCust.GetAll(parameters);

            }
            catch { }
            return PartialView("_DataList", Result);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Customer model)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    object[] parameters = { model.CustName, model.CustEmail };
                    result = objCust.Insert(parameters);
                    if (result == 1)
                    {
                        //Notify to all
                        CustomerHub.BroadcastData();
                    }
                }
            }
            catch { }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            int result = 0;
            try
            {
                object[] parameters = { id };
                result = objCust.Delete(parameters);
                if (result == 1)
                {
                    //Notify to all
                    CustomerHub.BroadcastData();
                }
            }
            catch { }
            return View("Index");
        }

        public ActionResult Update(int id)
        {
            object result = null;
            try
            {
                object[] parameters = { id };
                result = this.objCust.GetbyID(parameters);
            }
            catch { }
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Customer model)
        {
            int result = 0;
            try
            {
                object[] parameters = { model.Id, model.CustName, model.CustEmail };
                result = objCust.Update(parameters);

                if (result == 1)
                {
                    //Notify to all
                    CustomerHub.BroadcastData();
                }
            }
            catch { }
            return View("Index");
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}