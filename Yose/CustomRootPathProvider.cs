using System;
using System.IO;
using Nancy;
using System.Web.Script.Serialization;

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
