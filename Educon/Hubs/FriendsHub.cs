using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Educon.Core;
using Educon.Models;

namespace Educon.Hubs
{
    public class FriendsHub : Hub
    {
        public override Task OnConnected()
        {
            User LUser;

            using (UserCore LUserCore = new UserCore())
            {
                LUser = LUserCore.GetUserByName(Context.User.Identity.Name);
                LUserCore.SetUserOnline(LUser);
            }

            Clients.All.UserOnline(LUser.NamUser);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            User LUser;

            using (UserCore LUserCore = new UserCore())
            {
                LUser = LUserCore.GetUserByName(Context.User.Identity.Name);
                LUserCore.SetUserOffline(LUser);
            }

            Clients.All.UserOffline(LUser.NamUser);

            return base.OnDisconnected(stopCalled);
        }
    }
}