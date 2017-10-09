using Educon.Data.Interfaces;
using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Core
{
    public class QuizCore
    {
        private IQuizRepository FRepository;

        public QuizCore()
        {
            FRepository = DependencyResolver.Resolve<IQuizRepository>();
        }

        public Question GetQuestion(int ANidQuestion)
        {
            return FRepository.GetQuestion(ANidQuestion);
        }

        public ICollection<Question> GetQuestionListForMatch(string ANamUser1, string ANamUser2, int ANumQuestions)
        {
            User LUser1 = FRepository.GetUserByName(ANamUser1);
            User LUser2 = FRepository.GetUserByName(ANamUser2);

            AgeGroup LMinAgeGroup = LUser1.AgeGroup < LUser2.AgeGroup ? LUser1.AgeGroup : LUser2.AgeGroup;
            ICollection<Question> LQuestionsOfAgeGroup = FRepository.GetQuestionsForAgeGroup(LMinAgeGroup);

            // Questões que ainda não foram respondidas por nenhum dos 2 usuários
            ICollection<Question> LNewQuestions = LQuestionsOfAgeGroup
                .Where(q =>
                    !q.UserQuestions.Any(u => u.NidUser == LUser1.NidUser) &&
                    !q.UserQuestions.Any(u => u.NidUser == LUser2.NidUser)
                )
                .ToList();

            // Questões que ainda não foram respondidas por algum dos 2 usuários
            ICollection<Question> LNewForOneUserQuestions = LQuestionsOfAgeGroup
                .Where(q =>
                    !q.UserQuestions.Any(u => u.NidUser == LUser1.NidUser) ||
                    !q.UserQuestions.Any(u => u.NidUser == LUser2.NidUser)
                )
                .OrderBy(q => q.UserQuestions.Select(u => u.QtdAnswers))
                .ToList();

            // Questões que vou retornar
            List<Question> LReturnQuestions = new List<Question>();

            // Adiciono na lista o número de questões pedido
            LReturnQuestions.AddRange(LNewQuestions.Take(ANumQuestions));

            // Se as questões que nenhum dos usuários respondeu não foram suficientes,
            // uso as repetidas entre um dos usuários
            if (LReturnQuestions.Count < ANumQuestions)
            {
                LReturnQuestions.AddRange(LNewForOneUserQuestions.Take(ANumQuestions - LReturnQuestions.Count));
            }

            // Se ainda não foi o suficiente, aí adiciono as que os 2 já responderam
            if (LReturnQuestions.Count < ANumQuestions)
            {
                // Removo as que eu já adicionei, pra não repetir
                foreach (Question LQuestion in LReturnQuestions)
                {
                    LQuestionsOfAgeGroup.Remove(LQuestion);
                }

                LQuestionsOfAgeGroup.OrderBy(q => q.UserQuestions.Select(u => u.QtdAnswers));

                LReturnQuestions.AddRange(LQuestionsOfAgeGroup.Take(ANumQuestions - LReturnQuestions.Count));
            }

            return LReturnQuestions;
        }

        public void IncreaseUserExperience(int AExperience, int ANidUser)
        {
            FRepository.IncreaseUserExperience(AExperience, ANidUser);
        }


        public void ComputeAnswer(int ANidUser, int ANidQuestion)
        {
            FRepository.ComputeAnswer(ANidUser, ANidQuestion);
        }
    }
}
