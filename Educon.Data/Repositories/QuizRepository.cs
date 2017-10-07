using System;
using Educon.Data.Interfaces;
using Educon.Models;
using System.Linq;

namespace Educon.Data
{
    public class QuizRepository : IQuizRepository
    {
        EduconContext FContext = new EduconContext();

        public void ComputeAnswer(int ANidUser, int ANidQuestion)
        {
             
        }

        public Question GetQuestion(int ANidQuestion)
        {
            return FContext.Questions.Where(m => m.NidQuestion == ANidQuestion).FirstOrDefault();
        }
    }
}
