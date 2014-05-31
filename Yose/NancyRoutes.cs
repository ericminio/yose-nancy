using System;
using System.IO;
using Nancy;
using System.Collections.Generic;

namespace Yose
{
	public class NancyRoutes : NancyModule
	{
		public NancyRoutes ()
		{
			Get["/"] = _ => { return View["index.html"]; };
			Get["/ping"] = _ => Response.AsJson( new { alive = true } );
			Get["/primeFactors"] = PrimeFactorsEndpoint;
			Get["/minesweeper"] = _ => { return View["minesweeper.html"]; };
		}

		object PrimeFactorsEndpoint (dynamic parameters)
		{
			var number = Request.Query.number;

			return Response.AsJson(new ResponseContent { 
				Number = number,
				Decomposition = new Mathematician().PrimeFactorsOf(number)
			});
		}
	}
}

