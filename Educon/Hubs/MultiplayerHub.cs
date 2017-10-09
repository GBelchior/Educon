using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Educon.Hubs
{
    public class MultiplayerHub : Hub
    {
        public static IHubContext HubContext
        {
            get
            {
                return GlobalHost.ConnectionManager.GetHubContext<MultiplayerHub>();
            }
        }
    }
}