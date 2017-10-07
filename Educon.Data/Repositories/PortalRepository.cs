using Educon.Data.Interfaces;
using System.Collections.Generic;
using Educon.Models;

namespace Educon.Data
{
    public class PortalRepository : IPortalRepository
    {
        EduconContext FContext;

        public PortalRepository()
        {
            FContext = new EduconContext();
        }

        public void Dispose()
        {
            FContext.Dispose();
        }

        public Question GetQuestion(int ANidQuestion)
        {
            return QuestionRepository.GetQuestion(FContext, ANidQuestion);
        }

        public List<Question> GetQuestions(int ANidUser, AgeGroup AAgeGroup, Category? ANumCategory)
        {
            return QuestionRepository.GetQuestions(FContext, ANidUser, AAgeGroup, ANumCategory);
        }

        public User GetUserByName(string ANamUser)
        {
            return UserRepository.GetUserByName(FContext, ANamUser);
        }
    }
}
