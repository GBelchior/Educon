using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data.Interfaces
{
    public interface IPortalRepository : IDisposable
    {
        List<Question> GetQuestions(AgeGroup AAgeGroup, Category? ANidCategory);
        Question GetQuestion(int ANidQuestion);
        User GetUserByName(string ANamUser);
        List<User> GetUsers();
        ICollection<User> GetFriendsOfUser(int ANidUser);
        void AddFriend(User AUser, User ANewFriend);
    }
}
