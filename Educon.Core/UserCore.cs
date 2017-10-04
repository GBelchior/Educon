using Educon.Data.Interfaces;
using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Core
{
    public class UserCore : EduconCoreBase<User>
    {
        public IUserRepository Repository { get { return (IUserRepository)FRepository; } }

        public UserCore() : base(DependencyResolver.Resolve<IUserRepository>()) { }

        public User GetUserByEmail(string ADesEmail)
        {
            return Repository.GetUserByEmail(ADesEmail);
        }

        public User GetUserByName(string AUserName)
        {
            return Repository.GetUserByName(AUserName);
        }

        public void AddFriend(User AUser, User ANewFriend)
        {
            AUser.Friends.Add(ANewFriend);
            Repository.Save();
        }

        public ICollection<User> SearchUser(string AUserNameSearch)
        {
            return Repository.SearchUser(AUserNameSearch);
        }

        public void SetUserOnline(User AUser)
        {
            AUser.IsOnline = true;
            Repository.Save();
        }

        public void SetUserOffline(User AUser)
        {
            AUser.IsOnline = false;
            Repository.Save();
        }
    }
}
