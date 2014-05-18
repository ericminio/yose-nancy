using System;
using NUnit.Framework;
using Nancy.Testing;
using Yose;
using System.Web.Script.Serialization;

namespace Tests
{
	[TestFixture]
	public class HelloYoseTest
	{
		private Browser browser;
		private BrowserResponse result;

		[SetUp]
		public void HelloYoseModule()
		{
			browser = new Browser(with => with.Module(new HelloYoseModule()));
			result = browser.Get("/", with => { with.HttpRequest(); });
		}

		[Test]
		public void ReturnsHtml ()
		{
			Assert.That(result.ContentType, Is.StringContaining("text/html"));
		}

		[Test]
		public void ReturnsTheValueExpectedByYose ()
		{
			Assert.That(result.Body.AsString(), Is.StringContaining("Hello Yose"));
		}
	}
}

