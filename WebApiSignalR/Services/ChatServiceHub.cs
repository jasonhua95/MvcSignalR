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
		//所有的ConnectionId，时间的作用将来设置定时器，每隔多长时间清理下无用的ConnectionId
		public static ConcurrentDictionary<string,DateTime> AllConnectionIDs = new ConcurrentDictionary<string, DateTime>();
		//用户的ConnectionID，一个ID对应一个用户
		public static ConcurrentDictionary<string, string> UserConnectionIDs = new ConcurrentDictionary<string, string>();

		private Random rd = new Random();

		/// <summary>
		/// 根据不同的用户设置不同的信息
		/// </summary>
		/// <param name="userId"></param>
		public void LoginOn(string userId)
		{
			UserConnectionIDs.AddOrUpdate(userId, Context.ConnectionId, (key, oldValue) => Context.ConnectionId);
		}

		public void SendMessage(string message)
		{
			//Clients.All.receiveMessage(message + rd.Next(1000));
			Clients.Client(Context.ConnectionId).receiveMessage(message + rd.Next(1000));
		}

		/// <summary>
		/// API推送消息
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="message"></param>
		public void ReceiveMessage(string userId, string message)
		{
			if (UserConnectionIDs.ContainsKey(userId))
			{
				string id = UserConnectionIDs[userId];
				Clients.Client(id).receiveMessage(message);
			}
		}

		public override Task OnConnected()
		{
			AllConnectionIDs.AddOrUpdate(Context.ConnectionId, DateTime.Now, (key, oldValue) => DateTime.Now);
			return base.OnReconnected();
		}
	}
}