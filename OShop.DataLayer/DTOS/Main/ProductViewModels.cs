using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.DataLayer.DTOS.Main
{
    public class ShowProductViewModel
    {

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int SellCount { get; set; } = 0;
        public bool IsExists { get; set; } = true;
        public string Thumbnail { get; set; } = "No.png";
        public double Price { get; set; } = 0;
        public string Seller { get; set; }
        public int ProductGroupId { get; set; }
    }
}
