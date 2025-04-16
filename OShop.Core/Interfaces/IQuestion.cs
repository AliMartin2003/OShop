using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OShop.DataLayer.Entities;

namespace OShop.Core.Interfaces
{
    internal interface IQuestion
    {
        bool CreateQuestion(Question question);
        bool UpdateQuestion(Question question);
        IEnumerable<Question> GetQuestions();
        Question GetQuestion(int questionId);
        bool DeleteQuestion(int questionId);
    }
}
