using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ProductAssignment.Models;

namespace ProductAssignment.Controllers
{
    public class UnitcrudController : Controller
    {
        // GET: Unitcrud
        HttpClient client = new HttpClient();
        ProductDetails1Entities db = new ProductDetails1Entities();


        public ActionResult Index()
        {
            // List<UnitTB> Pro_list = new List<UnitTB>();
            List<UnitTB> Pro_list = db.UnitTBs.ToList();
            client.BaseAddress = new Uri("http://localhost:55898/Help/api/Get-api-Unitapi");
            var response = client.GetAsync("Unitapi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<UnitTB>>();
                display.Wait();
                Pro_list = display.Result;
            }


            return View(Pro_list);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public ActionResult Create(UnitTB pro)
        {


            client.BaseAddress = new Uri("http://localhost:55898/api/get-api-Unitapi");
            var response = client.PostAsJsonAsync<UnitTB>("Unitapi", pro);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View("Create");
        }




    }
}