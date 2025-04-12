using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.DataLayer.Entities;

namespace OShop.Core.Interfaces
{
    public interface IProductGroup
    {
        bool CreateProductGroup(ProductGroup productGroup);
        bool UpdateProductGroup(ProductGroup productGroup);
        IEnumerable<ProductGroup> GetProductGroups();
        ProductGroup GetProductGroup(int productId);
        bool DeleteProductGroup(int productId);

    }
}
