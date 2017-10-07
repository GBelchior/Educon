using Educon.Data.Interfaces;
using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
