using Educon.Data.Interfaces;
using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data
{
    public class UserQuestionRepository : EduconRepositoryBase<UserQuestion>, IUserQuestionRepository
    {
        public static void ComputeUserQuestion(EduconContext AContext, int ANidUser, int ANidQuestion)
        {
            User LUser = UserRepository.GetUser(AContext, ANidUser);
            Question LQuestion = QuestionRepository.GetQuestion(AContext, ANidQuestion);
            UserQuestion LUserQuestion = AContext.UserQuestions.ToList().SingleOrDefault(uq => uq.NidUser == LUser.NidUser && uq.NidQuestion == LQuestion.NidQuestion);

            if (LUserQuestion == null)
            {
                LUserQuestion = new UserQuestion
                {
                    NidUser = LUser.NidUser,
                    NidQuestion = LQuestion.NidQuestion,
                    QtdAnswers = 1
                };

                AContext.UserQuestions.Add(LUserQuestion);
            }
            else
            {
                LUserQuestion.QtdAnswers++;
            }
        }
    }
}
