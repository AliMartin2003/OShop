using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.Core.Interfaces;
using OShop.DataLayer.Context;
using OShop.DataLayer.Entities;

namespace OShop.Core.Services
{
    public class ProductGroupServices : IProductGroup
    {
        private readonly OShopContext _context;
        public ProductGroupServices(OShopContext context)
        {
            _context = context;
        }
        public bool CreateProductGroup(ProductGroup productGroup)
        {
            try
            {
                _context.ProductGroups.Add(productGroup);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }
        }

        public bool DeleteProductGroup(int productId)
        {
            throw new NotImplementedException();
        }

        public ProductGroup GetProductGroup(int productId)
        {
            return _context.ProductGroups.FirstOrDefault(pg=> pg.ProductGroupId==productId);
        }

        public IEnumerable<ProductGroup> GetProductGroups()
        {
            return _context.ProductGroups;
        }

        public bool UpdateProductGroup(ProductGroup productGroup)
        {
			try
			{
                _context.ProductGroups.Update(productGroup);
                _context.SaveChanges();
                return true;
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
                return false;
			}
        }
    }
}
