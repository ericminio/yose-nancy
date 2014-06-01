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

			Get["/static/{file}"] = p =>
			{
				string path = string.Format("static/{0}", p.file);
				var content = File.ReadAllText(path);
				var response = (Response) content;
				response.ContentType = "application/javascript";

				return response;
			};
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

