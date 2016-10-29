using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class ProductController : ApiController
    {


        // GET api/product
        public List<ProductModel> Get()
        {
            IReadable product = new ProductModel();


            return product.List().Cast<ProductModel>().ToList();
        }

        // GET api/product/5
        public Product Get(int id)
        {
            IReadable product = new ProductModel();

            return (Product)product.Get(id);
        }

        // POST api/product
        public void Post([FromBody]ProductModel model)
        {
            IEditable product = new ProductModel();

            Product newProduct = new Product()
            {
                ProductNumber = model.ProductNumber,
                Name = model.Name,
                ModifiedDate = DateTime.Now,
                SellStartDate = DateTime.Now
            };

            product.Insert(newProduct);
        }

        // PUT api/product/5
        public void Put(int id, [FromBody]ProductModel model)
        {

            IEditable product = new ProductModel();

            Product updateProduct = new Product()
            {
                ProductNumber = model.ProductNumber,
                Name = model.Name,
                ModifiedDate = DateTime.Now,
                SellStartDate = DateTime.Now
            };

            product.Update(id, updateProduct);
        }

        // DELETE api/product/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            //if(_db != null)
            //{
            //    _db.Dispose();
            //}

            base.Dispose(disposing);
        }
    }
}
