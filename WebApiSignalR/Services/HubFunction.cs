using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MvcSignalR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSignalR.Services
{
	public class HubFunction
	{
		public void ReceiveMessage(string userId, string message)
		{
			if (ChatServiceHub.UserConnectionIDs.ContainsKey(userId)) {
				IHubConnectionContext<dynamic> clients = GlobalHost.ConnectionManager.GetHubContext<ChatServiceHub>().Clients;
				string id = ChatServiceHub.UserConnectionIDs[userId];
				clients.Client(id).receiveMessage(message);
			}
		}
	}
}