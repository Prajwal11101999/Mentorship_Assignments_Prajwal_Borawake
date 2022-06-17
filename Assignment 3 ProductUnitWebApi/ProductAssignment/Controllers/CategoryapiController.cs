using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ProductAssignment.Models;

namespace ProductAssignment.Controllers
{
    public class CategoryapiController : ApiController
    {
        ProductDetails1Entities db = new ProductDetails1Entities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCategory()
        {
            List<CategoryTB> list = db.CategoryTBs.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var pro = db.CategoryTBs.Where(model => model.Category_ID == id).FirstOrDefault();

            return Ok(pro);

        }


        public IHttpActionResult CatInsert(CategoryTB p)
        {
            db.CategoryTBs.Add(p);
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult ProUpdate(CategoryTB p)
        {
            var cat = db.CategoryTBs.Where(model => model.Category_ID == p.Category_ID).FirstOrDefault();
            if (cat != null)
            {
                // p.ID = p.ID;
                cat.Category_ID = p.Category_ID;
                cat.Category_Name = p.Category_Name;


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
            var emp = db.CategoryTBs.Where(model => model.Category_ID == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }



    }
}

