using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiSignalR.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}

		public ActionResult ApiIndex()
		{
			ViewBag.Title = "Home Page";

			return View();
		}
	}
}
