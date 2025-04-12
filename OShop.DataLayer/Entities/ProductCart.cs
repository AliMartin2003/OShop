using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.DataLayer.Entities
{
    public class ProductCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int ProductCount { get; set; }
        public double TotalPrice
        {
            get
            {
                return Product.Price * ProductCount;
            }
        }

        #region Relations
        public User User { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}
