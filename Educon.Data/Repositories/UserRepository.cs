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

        public static List<User> GetUsers(EduconContext AContext)
        {
            return AContext.Users.ToList();
        }

        public User GetUserByNamePassword(string AUserName, string ADesPassword)
        {
            return FContext.Users
                .SingleOrDefault(u => u.NamUser.Equals(AUserName, StringComparison.InvariantCulture) && u.DesPassword.Equals(ADesPassword));
        }

        public User GetUserByName(string AUserName)
        {

            return GetUserByName(FContext, AUserName);

        }

        public static User GetUserByName(EduconContext AContext, string AUserName)
        {
            return AContext.Users
               .SingleOrDefault(u => u.NamUser.Equals(AUserName, StringComparison.InvariantCultureIgnoreCase));

        }

        public User GetUserByEmail(string ADesEmail)
        {
            return FContext.Users.SingleOrDefault(u => u.DesEmail.Equals(ADesEmail));
        }

        public ICollection<User> SearchUser(string AUserNameSearch)
        {
            return FContext.Users
                .Where(u => u.NamUser.Contains(AUserNameSearch) || u.NamPerson.Contains(AUserNameSearch))
                .ToList();
        }

        public static User GetFriendsOfUser(EduconContext AContext, int ANidUser)
        {
            return AContext.Users.Where(u => u.NidUser == ANidUser).Include(p => p.Friends).FirstOrDefault();
            
        }

        public static void AddFriend(EduconContext AContext,User AUser, User ANewFriend)
        {
            User LUser = GetUserByName(AContext, AUser.NamUser);
            User LNewFriend = GetUserByName(AContext, ANewFriend.NamUser);
            LUser.Friends.Add(LNewFriend);
            LNewFriend.Friends.Add(LUser);
            AContext.SaveChanges();
        }

     
    }
}
