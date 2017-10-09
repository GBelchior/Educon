using System.Collections.Generic;
using Educon.Models;

namespace Educon.Data.Interfaces
{
    public interface IQuizRepository 
    {
        void IncreaseUserExperience(int AExperience, int ANidUser);
        Question GetQuestion(int ANidQuestion);
        void ComputeAnswer(int ANidUser, int ANidQuestion);
        User GetUserByName(string ANamUser);
        ICollection<Question> GetQuestionsForAgeGroup(AgeGroup AAgeGroup);
    }
}
