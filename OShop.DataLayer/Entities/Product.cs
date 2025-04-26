using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.DataLayer.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Views { get; set; } = 0;
        public int SellCount { get; set; } = 0;
        public DateTimeOffset PublishDate { get; set; }
        public bool IsExists { get; set; }=true;
        public bool IsDeleted { get; set; } = false;
        public bool IsPublished { get; set; } = true;
        public string Thumbnail { get; set; } = "No.png";
        public double Price { get; set; } = 0;
        public int? UserId { get; set; }
        public int ProductGroupId { get; set; }

        #region Relations
        [ForeignKey("ProductGroupId")]
        public ProductGroup ProductGroup { get; set; }
        public ICollection<Gallery> Galleries { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Question> Questions { get; set; }
       
        public User Seller { get; set; }

        #endregion

    }
}
