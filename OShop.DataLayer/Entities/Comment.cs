using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.DataLayer.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentMessage { get; set; }
        public DateTimeOffset CommentDate { get; set; }
        public int? SenderId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }
        public User Sender { get; set; }
    }
}
