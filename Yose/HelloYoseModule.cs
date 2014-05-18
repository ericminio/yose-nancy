using System;
using Nancy;

namespace Yose
{
	public class HelloYoseModule : NancyModule
	{
		public HelloYoseModule ()
		{
			Get["/"] = _ => { return View["index.html"]; };
		}
	}
}

