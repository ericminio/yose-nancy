using System;
using Nancy;

namespace Yose
{
	public class PingModule : NancyModule
	{
		public PingModule ()
		{
			Get["/ping"] = _ => Response.AsJson( new { alive = true } );
		}
	}
}

