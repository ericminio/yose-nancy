using System;
using NUnit.Framework;
using Nancy.Testing;
using Yose;
using System.Web.Script.Serialization;

namespace Tests
{
	[TestFixture]
	public class PingChallenge
	{
		private Browser browser;
		private BrowserResponse result;

		[SetUp]
		public void PingModule()
		{
			browser = new Browser(with => with.Module(new NancyRoutes()));
			result = browser.Get("/ping", with => { with.HttpRequest(); });
		}

		[Test]
		public void ReturnsAJson ()
		{
			Assert.That(result.ContentType, Is.StringContaining("application/json"));
		}

		[Test]
		public void ReturnsTheValueExpectedByYose ()
		{
			dynamic content = new JavaScriptSerializer ().Deserialize<dynamic>(result.Body.AsString());

			Assert.That(content["alive"], Is.EqualTo(true));
		}

		[Test]
		public void ReturnsNoMoreThanTheValueExpectedByYose ()
		{
			dynamic content = new JavaScriptSerializer ().Deserialize<dynamic>(result.Body.AsString());

			Assert.That(content.Count, Is.EqualTo(1));
		}
	}
}

