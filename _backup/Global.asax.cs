using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace Gallery.Web
{
	public class Global : System.Web.HttpApplication
	{

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Add("Default", new Route(
				"{username}",
				new CustomRouteHandler("~/Default.aspx")
			));
		}

		protected void Application_Start()
		{
			RegisterRoutes(RouteTable.Routes);
		}
	}
}