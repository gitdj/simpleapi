using SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SampleWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: Products


        private static List<Products> products = new List<Products>()
        { new Products { ProductId =1, Name="MacApple", Price=100, Quantity=2},
                 new Products { ProductId =2, Name="Samsung", Price=90, Quantity=2},
                  new Products { ProductId =3, Name="Moto", Price=70, Quantity=2},
                   new Products { ProductId =4, Name="Nokia", Price=60, Quantity=2},
                   new Products { ProductId =5, Name="Deployment", Price=60, Quantity=2},
                   new Products { ProductId =6, Name="DeploymentSCM", Price=60, Quantity=2},
                   new Products { ProductId =7, Name="DeploymentDeploymentSlot", Price=60, Quantity=2} };

        public IEnumerable<Products> Get()
        {
            return products.ToArray();
        }


        public Products Get(int Id)
        {
            return products.Where(x => x.ProductId == Id).FirstOrDefault(); 
        }


        public IHttpActionResult Post(Products prod)
        {
            products.Add(prod);
            return Ok();
        }



        public IHttpActionResult Put(Products prod)
        {
            var p1= products.Where(x=>x.ProductId==prod.ProductId).FirstOrDefault();
            if (p1!=null)
            {
               products.Remove(p1);
               products.Add(prod);
                return Ok(prod);
            }
            return NotFound();
        }



        public IHttpActionResult DELETE(Products prod)
        {
            var p1 = products.Where(x => x.ProductId == prod.ProductId).FirstOrDefault();
            if (p1 != null)
            {
                products.Remove(p1);
                return Ok();
            }
            return NotFound();
        }
    }
}