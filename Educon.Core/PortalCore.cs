using Educon.Data.Interfaces;
using Educon.Models;
using System.Collections.Generic;
using System.Linq;

namespace Educon.Core
{
    public class PortalCore
    {
        private IPortalRepository FRepository;

        public PortalCore()
        {
            FRepository = DependencyResolver.Resolve<IPortalRepository>();
        }

        public List<Question> GetQuestions(int ANidUser, AgeGroup AAgeGroup, Category? ANumCategory)
        {
            return FRepository.GetQuestions(ANidUser, AAgeGroup, ANumCategory);
        }

        public User GetUserByName(string ANamUser)
        {
            return FRepository.GetUserByName(ANamUser);
        }

        public Question GetQuestion(int ANidQuestion)
        {
            return FRepository.GetQuestion(ANidQuestion);
        }

        public IOrderedEnumerable<User> GetRankingList()
        {
            return FRepository.GetUsers()
                .OrderBy(u => u.QtdExperience);
        }
    }
}
