using System;
using System.IO;
using Nancy;

namespace Yose
{

	public class CustomRootPathProvider : IRootPathProvider
	{
		public string GetRootPath()
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "views");
		}
	}
}
