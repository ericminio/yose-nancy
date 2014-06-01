using System;
using System.IO;
using Nancy;
using Nancy.Conventions;

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

		protected override void ConfigureConventions(NancyConventions nancyConventions)
		{
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Static", @"Static"));
			base.ConfigureConventions(nancyConventions);
		}
	}
	
}
