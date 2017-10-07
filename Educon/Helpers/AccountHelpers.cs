using Educon.Core;
using Educon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Educon.Helpers
{
    public static class AccountHelpers
    {
        public static void SignIn(User AUser)
        {
            if (AUser == null) return;

            FormsAuthentication.SetAuthCookie(AUser.NamUser, false);
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public static User GetSignedUser()
        {
            // Se o usuário não está autenticado, retorna null
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return null;

            // Retorna o usuário autenticado que encontrou no banco
            using (UserCore LUserCore = new UserCore())
            {
                return LUserCore.GetUserByName(HttpContext.Current.User.Identity.Name);
            }
        }
    }
}