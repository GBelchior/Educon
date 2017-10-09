using System;
using Educon.Data.Interfaces;
using Educon.Models;
using System.Linq;
using System.Collections.Generic;

namespace Educon.Data
{
    public class QuizRepository : IQuizRepository
    {
        EduconContext FContext = new EduconContext();

        public void ComputeAnswer(int ANidUser, int ANidQuestion)
        {
            UserQuestionRepository.ComputeUserQuestion(FContext, ANidUser, ANidQuestion);
            UserRepository.ComputeQuestionCategory(FContext, ANidUser, ANidQuestion);
        }

        public Question GetQuestion(int ANidQuestion)
        {
            return FContext.Questions.Where(m => m.NidQuestion == ANidQuestion).FirstOrDefault();
        }

        public ICollection<Question> GetQuestionsForAgeGroup(AgeGroup AAgeGroup)
        {
            return QuestionRepository.GetQuestionsForAgeGroup(FContext, AAgeGroup);
        }

        public User GetUserByName(string ANamUser)
        {
            return UserRepository.GetUserByName(FContext, ANamUser);
        }
    }
}
