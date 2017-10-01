using Educon.Data.Interfaces;
using Educon.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Educon.Data
{
    public class MultiplayerRepository : IMultiplayerRepository
    {
        private EduconContext FContext;

        public MultiplayerRepository()
        {
            FContext = new EduconContext();
        }

        public void ComputeAnswer(int ANidUser, int ANidQuestion)
        {
            UserQuestionRepository.ComputeUserQuestion(FContext, ANidUser, ANidQuestion);
            UserRepository.ComputeQuestionCategory(FContext, ANidUser, ANidQuestion);
        }

        public int GetCorrectAnswer(int ANidQuestion)
        {
            return QuestionRepository.GetQuestion(FContext, ANidQuestion).NumCorrectAnswer;
        }

        public ICollection<User> GetOnlineFriends(int ANidUser)
        {
            return UserRepository.GetUser(FContext, ANidUser)
                .Friends
                .Where(f => f.IsOnline)
                .ToList();
        }

        public Question GetQuestion(int ANidQuestion)
        {
            return QuestionRepository.GetQuestion(FContext, ANidQuestion);
        }

        public ICollection<Question> GetQuestions()
        {
            return QuestionRepository.GetQuestions(FContext);
        }

        public ICollection<Question> GetQuestionsForAgeGroup(AgeGroup AAgeGroup)
        {
            return QuestionRepository.GetQuestionsForAgeGroup(FContext, AAgeGroup);
        }

        public void Save()
        {
            FContext.SaveChanges();
        }
    }
}
