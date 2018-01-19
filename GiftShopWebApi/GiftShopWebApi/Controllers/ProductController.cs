using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GiftShopWebApi.Models;
using GiftShopWebApi.Models.DTO;

namespace GiftShopWebApi.Controllers
{
    public class ProductController : ApiController
    {
        private GiftShopWebApiContext db = new GiftShopWebApiContext();

        [HttpGet]
        public IHttpActionResult Product(int quantity, int page)
        {
            int startRow = (quantity * page ) - quantity;
            var query = (from p in db.Products
                         select new ProductDTO()
                         {
                             ProductID = p.ProductID,
                             Name = p.Name,
                             ImageName = p.ImageName,
                             price = p.price
                         })
                        .OrderBy(p => p.ProductID)
                        .Skip(startRow).Take(quantity);
            IEnumerable<ProductDTO> products = query.ToList();
            return Ok(products);
        }

        [HttpGet]
        public IHttpActionResult ProductDetail(int id)
        {
            Product product = db.Products.Find(id);
            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditProduct(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id) {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return Ok(product);
        }

        //// GET api/Product
        //public IQueryable<Product> GetProducts()
        //{
        //    return db.Products;
        //}

        //// GET api/Product/5
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult GetProduct(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}

        //// PUT api/Product/5
        //public IHttpActionResult PutProduct(int id, Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.ProductID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/Product
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult PostProduct(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        //}

        //// DELETE api/Product/5
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult DeleteProduct(int id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Products.Remove(product);
        //    db.SaveChanges();

        //    return Ok(product);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ProductExists(int id)
        //{
        //    return db.Products.Count(e => e.ProductID == id) > 0;
        //}
    }
}