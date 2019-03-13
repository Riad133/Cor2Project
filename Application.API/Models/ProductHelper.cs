using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.API.Models
{
    public static class ProductHelper
    {
        public static  List<Product> Products = new List<Product>
        {
            new Product(){Id = 1, Name = "java how to program", Description = "It is a good book"},
            new Product(){Id = 1, Name = "C++ how to program", Description = "It is a good book"}
        };

        public static Product AddProduct(Product product)
        {
            Products.Add(product);

            return product;
        }

        public static Product GetProduct(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }

        public static List<Product> GetProducts()
        {
            return Products.ToList();
        }

        public static Product Update(int id, Product product)
        {
            var Aproduct = Products.FirstOrDefault(x => x.Id == id);
            Aproduct.Name = product.Name;
            Aproduct.Description = product.Description;
            return Aproduct;

        }

        public static List<Product> DeleteProduct(int id)
        {
            var products = Products.Where(x => x.Id != id).ToList();
            Products = products;
            return Products;
        }
    }
}
