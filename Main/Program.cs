using System;
using Nancy;
using Nancy.Hosting.Self;

namespace Main
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (var host = new NancyHost(new Uri("http://localhost:1234")))
			{
				StaticConfiguration.DisableErrorTraces = false;
				host.Start();
				Console.ReadLine();
			}
		}
	}
}
