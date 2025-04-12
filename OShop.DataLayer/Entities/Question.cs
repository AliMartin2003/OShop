using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.DataLayer.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionMessage { get; set; }
        public int? SenderId { get; set; }
        public string? Answer { get; set; } = null;
        public bool IsAnswered { get; set; } = false;
        public User Questioner { get; set; }
        public Product Product { get; set; }

    }
}
