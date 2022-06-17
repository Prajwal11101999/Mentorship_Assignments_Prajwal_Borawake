using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductAssignment.Models;

namespace ProductAssignment.Controllers
{
    public class ProductWebapiController : ApiController
    {

        ProductDetails1Entities db = new ProductDetails1Entities();

        [HttpGet]
        //[System.Web.Http.HttpGet]
        public IHttpActionResult GetProduct()
        {
            List<ProductTB> list = db.ProductTBs.ToList();
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult GetProductId(int ID)
        {
            var pro = db.ProductTBs.Where(model => model.Product_ID == ID).FirstOrDefault();

            return Ok(pro);

        }

        [HttpPost]
       // [System.Web.Http.HttpPost]
        public IHttpActionResult proInsert(ProductTB p)
        {
            db.ProductTBs.Add(p);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
       // [System.Web.Http.HttpPut]
        public IHttpActionResult ProUpdate(ProductTB p)
        {
            var pro = db.ProductTBs.Where(model => model.Product_ID == p.Product_ID).FirstOrDefault();
            if (pro != null)
            {
                int product_ID = p.Product_ID;
                pro.Product_ID = product_ID;
                pro.Product_Name = p.Product_Name;
                pro.Category_Id = p.Category_Id;
                pro.Unit_Id = p.Unit_Id;
                pro.Price = p.Price;


                db.SaveChanges();

            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete]
       // [System.Web.Http.HttpDelete]
        public IHttpActionResult ProDelete(int id)
        {
            var emp = db.ProductTBs.Where(model => model.Product_ID == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }




    }
}
