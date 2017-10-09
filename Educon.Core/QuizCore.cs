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

        public void IncreaseUserExperience(int AExperience, int ANidUser)
        {
            FRepository.IncreaseUserExperience(AExperience, ANidUser);
        }


        public void ComputeAnswer(int ANidUser, int ANidQuestion)
        {
            FRepository.ComputeAnswer(ANidUser, ANidQuestion);
        }

        public User GetUserByName(string ANamUser)
        {
            return FRepository.GetUserByName(ANamUser);
        }
    }
}
