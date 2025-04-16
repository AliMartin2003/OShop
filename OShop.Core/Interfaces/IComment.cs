using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.DataLayer.Entities;

namespace OShop.Core.Interfaces
{
    internal interface IComment
    {
        bool CreateComment(Comment comment);
        bool UpdateComment(Comment comment);
        IEnumerable<Comment> GetComments();
        Comment GetComment(int commentId);
        bool DeleteComment(int commentId);
    }
}
