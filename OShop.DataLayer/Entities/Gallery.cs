using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.DataLayer.Entities
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public string ImageName { get; set; }
        public int ProductId { get; set; }

        #region Relations
        public Product Product { get; set; }
        #endregion
    }
}
