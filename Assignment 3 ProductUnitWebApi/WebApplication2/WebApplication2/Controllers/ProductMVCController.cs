using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using WebApplication2.Models;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ProductMVCController : Controller
    {
        // GET: ProductMVC
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<ProductTB> prod_list = new List<ProductTB>();
            client.BaseAddress = new Uri("https://localhost:44350/api/ProductApi");
            var response = client.GetAsync("ProductApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<ProductTB>>();
                display.Wait();
                prod_list = display.Result;
            }
            return View(prod_list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductTB prod)
        {
            client.BaseAddress = new Uri("https://localhost:44350/Api/ProductApi");
            var response = client.PostAsJsonAsync<ProductTB>("ProductApi", prod);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Add(ProductTB s)
        {
            ProductDetails1Entities db = new ProductDetails1Entities();
            db.ProductTBs.Add(s);
            db.SaveChanges();
            db.Dispose();
            return Redirect("Index");
        }

        public ActionResult Details(int id)
        {
            ProductTB p = null;
            client.BaseAddress = new Uri("https://localhost:44350/Api/ProductApi");
            var response = client.GetAsync("ProductApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<ProductTB>();
                display.Wait();
                p = display.Result;
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductTB p = null;
            client.BaseAddress = new Uri("https://localhost:44350/Api/ProductApi");
            var response = client.GetAsync("ProductApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<ProductTB>();
                display.Wait();
                p = display.Result;
            }
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(ProductTB p)
        {
            client.BaseAddress = new Uri("https://localhost:44350/Api/ProductApi");
            var response = client.PutAsJsonAsync<ProductTB>("Product", p);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        public ActionResult Save(ProductTB s)
        {
            ProductDetails1Entities db = new ProductDetails1Entities();
            ProductTB p = db.ProductTBs.Where(x => x.Product_ID == s.Product_ID).FirstOrDefault();
            p.Product_Name = s.Product_Name;
            p.Price = s.Price;
            p.Category_Id = s.Category_Id;
            p.Unit_Id = s.Unit_Id;
            db.SaveChanges();
            db.Dispose();
            return Redirect("Index");
        }

        public ActionResult Delete(int id)
        {
            ProductTB p = null;
            client.BaseAddress = new Uri("https://localhost:44350/Api/ProductApi");
            var response = client.GetAsync("ProductApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<ProductTB>();
                display.Wait();
                p = display.Result;
            }
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44350/Api/ProductApi");
            var response = client.DeleteAsync("ProductApi/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");

        }
    }
}