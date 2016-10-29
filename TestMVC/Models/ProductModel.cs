using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVC.Models
{
        
    /// <summary>
    /// This is intermediate class between the MVC controller and the Entity Framwork, 
    /// if the case3 we have to do some change to the data, we can made here
    /// </summary>
    public class ProductModel : AbstractModel, IReadable, IEditable, IDisposable
    {
        public int Id { get; set; }
        public string ProductNumber { get; set; }
        public string Name { get; set; }

        prodigiousEntities _db = new prodigiousEntities();

        public ProductModel()
        {
            this.Id = 0;
            this.ProductNumber = "none";
            this.Name = "Empty instance";
        }

        public ProductModel( Product product)
        {
            this.Id = product.ProductID;
            this.ProductNumber = product.ProductNumber;
            this.Name = product.Name;
        }

        List<AbstractModel> IReadable.List()
        {
            List<AbstractModel> list = new List<AbstractModel>();

            var productList = _db.Product.Take(20).ToList();


            //Filter the values from the Entity, that I just need
            foreach (Product product in productList)
            {
                var productModel = new ProductModel(product);
                list.Add(productModel);
            }


            return list;
        }

        AbstractModel IReadable.Get(int id)
        {
            var productList =   (from product in _db.Product
                                where product.ProductID == id
                                select product).ToList();

            //IReadable item = new ProductModel();

            return productList.First();

        }

        bool IEditable.Insert(AbstractModel item)
        {
            if (item.GetType() == typeof(Product))
            {
                //_db.Product.Add((Product)item);
                //_db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }           
        }

        bool IEditable.Update(int id, AbstractModel item)
        {
            if (item.GetType() == typeof(Product))
            {
                var updateProduct = (Product)item;
                updateProduct.ProductID = Id;

                //_db.Product.Attach(updateProduct);
                //_db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }    
        }

        void IDisposable.Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}