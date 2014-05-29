using System;
using System.IO;
using Nancy;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace Yose
{
	public class NancyRoutes : NancyModule
	{
		public NancyRoutes ()
		{
			Get["/"] = _ => { return View["index.html"]; };
			Get["/ping"] = _ => Response.AsJson( new { alive = true } );
			Get ["/primeFactors?number={number}"] = PrimeFactorsEndpoint;
		}

		object PrimeFactorsEndpoint (dynamic parameters)
		{
			return Response.AsJson(new ResponseContent { 
				Number = parameters.number,
				Decomposition = new Mathematician().PrimeFactorsOf(parameters.number)
			});
		}
	}
}

