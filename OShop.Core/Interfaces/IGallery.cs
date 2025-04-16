using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.DataLayer.Entities;

namespace OShop.Core.Interfaces
{
    public interface IGallery
    {
        bool CreateGallery(Gallery gallery);
        bool UpdateGallery(Gallery gallery);
        IEnumerable<Gallery> GetGallerys();
        Gallery GetGallery(int galleryId);
        bool DeleteGallery(int galleryId);
    }
}
