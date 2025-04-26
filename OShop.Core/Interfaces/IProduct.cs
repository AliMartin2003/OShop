using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.DataLayer.Entities;

namespace OShop.Core.Services
{
    public interface IProduct
    {
        bool CreateProduct(Product productGroup);
        bool UpdateProduct(Product productGroup);
        IEnumerable<Product> GetProducts();
        Product GetProduct(int productId);
        bool DeleteProduct(int productId);
        int GetProductsCount();
    }
}
