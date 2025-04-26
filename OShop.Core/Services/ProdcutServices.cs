using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OShop.DataLayer.Context;
using OShop.DataLayer.Entities;

namespace OShop.Core.Services
{
    public class ProductServices : IProduct
    {
        private readonly OShopContext _context;
        public ProductServices(OShopContext context)
        {
            _context = context;
        }
        public bool CreateProduct(Product productGroup)
        {
            try
            {
                _context.Products.Add(productGroup);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string productName)
        {

            return _context.Products.Include(p => p.Seller).FirstOrDefault(p => p.ProductName == productName);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        public int GetProductsCount()
        {
            return _context.Products.Count();
        }

        public bool UpdateProduct(Product productGroup)
        {
            throw new NotImplementedException();
        }
    }
}
