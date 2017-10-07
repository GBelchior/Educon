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
        List<Question> GetQuestions(int ANidUser, AgeGroup AAgeGroup, Category? ANidCategory);
        Question GetQuestion(int ANidQuestion);
        User GetUserByName(string ANamUser);
        List<User> GetUsers();
        ICollection<User> GetFriendsOfUser(int ANidUser);

    }
}
