using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSignalR.Services;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using System.Threading.Tasks;

namespace WebApiSignalR.Controllers
{
	/// <summary>
	/// Api推送数据
	/// </summary>
	public class TestController : ApiController
	{
		private Random rd = new Random();

		/// <summary>
		/// http://localhost:51711/api/test/get/7043  调用api推送信息MVC和api的结合
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public string Get(string id)
		{
			HubFunction hub = new HubFunction();
			hub.ReceiveMessage(id, $"Api推送的消息{rd.Next(1000)}");
			return "信息推送成功";
		}

		/// <summary>
		/// http://localhost:51711/api/test/get/7043  调用api推送信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<string> ApiGet(string id)
		{
			var hubConnection = new HubConnection("http://localhost:51711");
			IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("ChatServiceHub");
			await hubConnection.Start(new LongPollingTransport());
			await stockTickerHubProxy.Invoke("ReceiveMessage", id, $"Api推送的消息{rd.Next(1000)}");

			return "信息推送成功";
		}
	}
}