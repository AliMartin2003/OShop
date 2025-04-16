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
        bool UpdateProductGroup(Product productGroup);
        IEnumerable<Product> GetProductGroups();
        Product GetProductGroup(int productId);
        bool DeleteProductGroup(int productId);
    }
}
