using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.DataLayer.Entities;

namespace OShop.Core.Interfaces
{
    public interface IProduct
    {
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        IEnumerable<Product> GetProducts();
        Task<Product> GetProductById(int id);


    }
}
