using Educon.Data.Interfaces;
using Educon.Models;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Educon.Data
{
    public class UserRepository : EduconRepositoryBase<User>, IUserRepository
    {
        public static User GetUser(EduconContext AContext, int ANidUser)
        {
            return AContext.Users
                .Include(u => u.Friends)
                .SingleOrDefault(u => u.NidUser == ANidUser);
        }

        internal static void ComputeQuestionCategory(EduconContext AContext, int ANidUser, int ANidQuestion)
        {
            Question LQuestion = QuestionRepository.GetQuestion(AContext, ANidQuestion);
            User LUser = GetUser(AContext, ANidUser);

            switch (LQuestion.Category)
            {
                case Category.Water: LUser.NumWaterAnswers++; break;
                case Category.Energy: LUser.NumEnergyAnswers++; break;
                case Category.Environment: LUser.NumEnvironmentAnswers++; break;
                case Category.Recycling: LUser.NumRecyclingAnswers++; break;
            }
        }

        public User GetUserByName(string AUserName)
        {
            return FContext.Users
                .SingleOrDefault(u => u.NamUser.Equals(AUserName, StringComparison.InvariantCultureIgnoreCase));
        }

        public ICollection<User> SearchUser(string AUserNameSearch)
        {
            return FContext.Users
                .Where(u => u.NamUser.Contains(AUserNameSearch) || u.NamPerson.Contains(AUserNameSearch))
                .ToList();
        }
    }
}
