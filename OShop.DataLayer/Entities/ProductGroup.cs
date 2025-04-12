using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.DataLayer.Entities
{
    public class ProductGroup
    {
        public int ProductGroupId { get; set; }
        public string ProducGrouptName { get; set; }
        public string ProductGroupImage { get; set; }

        #region Relations
        public ICollection<Product> Products { get; set; }

        #endregion

    }
}
