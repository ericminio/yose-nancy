using System;
using System.IO;
using Nancy;
using System.Web.Script.Serialization;

namespace Yose
{

	public class CustomBootstrapper : DefaultNancyBootstrapper
	{
		public CustomBootstrapper() 
		{
			StaticConfiguration.DisableErrorTraces = false;
		}

		protected override IRootPathProvider RootPathProvider
		{
			get { return new CustomRootPathProvider(); }
		}
	}
	
}
