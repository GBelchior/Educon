using Educon.Models;
using System.Collections.Generic;

namespace Educon.Data.Interfaces
{
    public interface IMultiplayerRepository
    {
        ICollection<User> GetOnlineFriends(int ANidUser);
        Question GetQuestion(int ANidQuestion);
        ICollection<Question> GetQuestions();
        ICollection<Question> GetQuestionsForAgeGroup(AgeGroup AAgeGroup);
        void ComputeAnswer(int ANidUser, int ANidQuestion);
        int GetCorrectAnswer(int ANidQuestion);
        void Save();
    }
}
