using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductApiController : ApiController
    {
        // GET api/<controller>
        ProductDetails1Entities db = new ProductDetails1Entities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetProducts()
        {
            List<ProductTB> list = db.ProductTBs.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            var pro = db.ProductTBs.Where(model => model.Product_ID == id).FirstOrDefault();

            return Ok(pro);

        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult ProdInsert(ProductTB p)
        {
            db.ProductTBs.Add(p);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult ProUpdate(ProductTB p)
        {
            var cat = db.ProductTBs.Where(model => model.Product_ID == p.Product_ID).FirstOrDefault();
            if (cat != null)
            {
                // p.ID = p.ID;
                cat.Product_ID = p.Product_ID;
                cat.Product_Name = p.Product_Name;
                cat.Price = p.Price;
                cat.Category_Id = p.Category_Id;
                cat.Unit_Id = cat.Unit_Id;

                db.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult ProDelete(int id)
        {
            var emp = db.ProductTBs.Where(model => model.Product_ID == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}