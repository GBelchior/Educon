using Educon.Data.Interfaces;
using Educon.Models;
using System.Collections.Generic;
using System.Linq;

namespace Educon.Core
{
    public class MultiplayerCore
    {
        private IMultiplayerRepository FRepository;

        public MultiplayerCore()
        {
            FRepository = DependencyResolver.Resolve<IMultiplayerRepository>();
        }

        public ICollection<Question> GetQuestionListForMatch(User AUser1, User AUser2, int ANumQuestions)
        {
            AgeGroup LMinAgeGroup = AUser1.AgeGroup < AUser2.AgeGroup ? AUser1.AgeGroup : AUser2.AgeGroup;

            ICollection<Question> LQuestionsOfAgeGroup = FRepository.GetQuestionsForAgeGroup(LMinAgeGroup);

            // Questões que ainda não foram respondidas por nenhum dos 2 usuários
            ICollection<Question> LNewQuestions = LQuestionsOfAgeGroup
                .Where(q =>
                    !q.UserQuestions.Any(u => u.NidUser == AUser1.NidUser) &&
                    !q.UserQuestions.Any(u => u.NidUser == AUser2.NidUser)
                )
                .ToList();

            // Questões que ainda não foram respondidas por algum dos 2 usuários
            ICollection<Question> LNewForOneUserQuestions = LQuestionsOfAgeGroup
                .Where(q =>
                    !q.UserQuestions.Any(u => u.NidUser == AUser1.NidUser) ||
                    !q.UserQuestions.Any(u => u.NidUser == AUser2.NidUser)
                )
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

                // TODO: ordenar as questões pelas menos respondidas de cada usuário

                LReturnQuestions.AddRange(LQuestionsOfAgeGroup.Take(ANumQuestions - LReturnQuestions.Count));
            }

            return LReturnQuestions;
        }

        public bool ValidateAnswer(int ANidUser, int ANidQuestion, int ANumAnswer)
        {
            Question LQuestion = FRepository.GetQuestion(ANidQuestion);

            if (LQuestion.NumCorrectAnswer == ANumAnswer)
            {
                FRepository.ComputeAnswer(ANidUser, ANidQuestion);
                FRepository.Save();
                return true;
            }

            return false;
        }

        public int GetCorrectAnswer(int ANidQuestion)
        {
            return FRepository.GetCorrectAnswer(ANidQuestion);
        }
    }
}
