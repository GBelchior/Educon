using Educon.Data.Interfaces;
using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data
{
    public class QuestionRepository : EduconRepositoryBase<Question>, IQuestionRepository
    {
        public static Question GetQuestion(EduconContext AContext, int ANidQuestion)
        {
            return AContext.Questions.Find(ANidQuestion);
        }

        public static ICollection<Question> GetQuestions(EduconContext AContext)
        {
            return AContext.Questions.ToList();
        }

        public static ICollection<Question> GetQuestionsForAgeGroup(EduconContext AContext, AgeGroup AAgeGroup)
        {
            return AContext.Questions
                .Where(q => q.AgeGroup == AAgeGroup)
                .ToList();
        }
    }
}
