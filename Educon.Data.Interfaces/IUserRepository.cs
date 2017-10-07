using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educon.Data.Interfaces
{
    public interface IUserRepository : IEduconRepositoryBase<User>
    {
        User GetUserByName(string AUserName);
        ICollection<User> SearchUser(string AUserNameSearch);
        User GetUserByEmail(string ADesEmail);
        User GetUserByNamePassword(string AUserName, string ADesPassword);
    }
}
