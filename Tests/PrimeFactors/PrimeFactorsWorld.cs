using System;
using NUnit.Framework;
using Nancy.Testing;
using Yose;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace Tests
{
	[TestFixture]
	public class PrimeFactorsWorld
	{
		private Browser browser;
		private BrowserResponse result;

		[SetUp]
		public void PrimeFactorsModule()
		{
			browser = new Browser(with => with.Module(new NancyRoutes()));
			result = browser.Get("/primeFactors", with => 
			{ 
				with.HttpRequest(); 
				with.Query("number", "8");
			});
		}

		[Test]
		public void IsOnline ()
		{
			Assert.That(result.StatusCode, Is.EqualTo(Nancy.HttpStatusCode.OK));
		}

		[Test]
		public void ReturnsAJson ()
		{
			Assert.That(result.ContentType, Is.StringContaining("application/json"));
		}

		[Test]
		public void ReturnsTheReceivedNumber ()
		{
			dynamic content = new JavaScriptSerializer ().Deserialize<dynamic>(result.Body.AsString());

			Assert.That(content["number"], Is.EqualTo(8));
		}

		[Test]
		public void ReturnsTheDecomposition ()
		{
			dynamic content = new JavaScriptSerializer ().Deserialize<dynamic>(result.Body.AsString());

			Assert.That(content["decomposition"], Is.EqualTo(new List<int> { 2, 2, 2 }));
		}
	}
}

