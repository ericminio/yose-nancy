using System;
using System.IO;
using Nancy;

namespace Yose
{
	public class NancyRoutes : NancyModule
	{
		public NancyRoutes ()
		{
			Get["/"] = _ => { return View["index.html"]; };
			Get["/ping"] = _ => Response.AsJson( new { alive = true } );
		}
	}

	public class CustomBootstrapper : DefaultNancyBootstrapper
	{
		protected override IRootPathProvider RootPathProvider
		{
			get { return new CustomRootPathProvider(); }
		}
	}

	public class CustomRootPathProvider : IRootPathProvider
	{
		public string GetRootPath()
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".");
		}
	}
}

