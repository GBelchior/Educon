using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Educon.Helpers
{
    public static class AccountHelpers
    {
        private static User SignedUser { get; set; }

        public static void SignIn(User AUser)
        {
            SignedUser = AUser;
        }

        public static User GetSignedUser()
        {
            return SignedUser;
        }
    }
}