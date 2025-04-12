using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.DataLayer.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ProductCartId { get; set; }

        #region Relations
        public ICollection<ProductCart> ProductCarts  { get; set; }
        #endregion




    }
}
