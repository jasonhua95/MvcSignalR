using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MvcSignalR.Services
{
	/// <summary>
	/// 数据交流类
	/// </summary>
	public class ChatServiceHub : Hub
	{
		//所有的ConnectionId
		public static ConcurrentDictionary<string,DateTime> AllConnectionIDs = new ConcurrentDictionary<string, DateTime>();
		//用户的ConnectionID，一个ID对应一个用户
		public static ConcurrentDictionary<string, string> UserConnectionIDs = new ConcurrentDictionary<string, string>();

		private Random rd = new Random();

		public void Send(string message)
		{
			int i = 0;
			while (i < 10000)
			{
				i++;
				Thread.Sleep(100);
				Clients.Client(Context.ConnectionId).broadcastMessage(Context.ConnectionId, message + rd.Next(1000));
			}
		}

		public void SendMessage(string message)
		{
			Clients.Client(Context.ConnectionId).receiveMessage(message + rd.Next(1000));
		}

		public override Task OnConnected()
		{
			AllConnectionIDs.AddOrUpdate(Context.ConnectionId, DateTime.Now, (key, oldValue) => DateTime.Now);
			return base.OnReconnected();
		}
	}
}