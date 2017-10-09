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

        public void AddFriend(User AUser, User ANewFriend)
        {
            FRepository.AddFriend(AUser, ANewFriend);
        }

        public List<Question> GetQuestions(int ANidUser, AgeGroup AAgeGroup, Category? ANumCategory)
        {
            return FRepository.GetQuestions(ANidUser, AAgeGroup, ANumCategory);
        }

        public ICollection<User> GetFriendsOfUser(int ANidUser)
        {
            return FRepository.GetFriendsOfUser(ANidUser);
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
                .OrderByDescending(u => u.QtdExperience);
        }
    }
}
