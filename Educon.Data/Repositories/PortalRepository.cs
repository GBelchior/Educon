using Educon.Data.Interfaces;
using System.Collections.Generic;
using Educon.Models;

namespace Educon.Data
{
    public class PortalRepository : IPortalRepository
    {
        EduconContext FContext;

        public PortalRepository()
        {
            FContext = new EduconContext();
        }

        public void Dispose()
        {
            FContext.Dispose();
        }

        public Question GetQuestion(int ANidQuestion)
        {
            return QuestionRepository.GetQuestion(FContext, ANidQuestion);
        }

        public List<Question> GetQuestions(AgeGroup AAgeGroup, Category? ANumCategory)
        {
            return QuestionRepository.GetQuestions(FContext, AAgeGroup, ANumCategory);
        }

        public List<User> GetUsers()
        {
            return UserRepository.GetUsers(FContext);
        }

        public User GetUserByName(string ANamUser)
        {
            return UserRepository.GetUserByName(FContext, ANamUser);
        }

        public void AddFriend(User AUser, User ANewFriend)
        {
            UserRepository.AddFriend(FContext, AUser, ANewFriend);
        }


        public ICollection<User> GetFriendsOfUser(int ANidUser)
        {
            return UserRepository.GetFriendsOfUser(FContext, ANidUser).Friends;
        }
    }
}
