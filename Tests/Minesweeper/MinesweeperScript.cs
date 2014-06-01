using System;
using NUnit.Framework;
using Nancy.Testing;
using Yose;

namespace Tests
{
	[TestFixture]
	public class MinesweeperScript
	{
		private Browser browser;
		private BrowserResponse result;

		[SetUp]
		public void TheScript()
		{
			browser = new Browser(with => with.Module(new NancyRoutes()));
			result = browser.Get("/static/minesweeper.js", with =>  { with.HttpRequest(); });
		}

		[Test]
		public void CanBeServed ()
		{
			Assert.That(result.StatusCode, Is.EqualTo(Nancy.HttpStatusCode.OK));
		}

		[Test]
		public void HasExpectedContentType()
		{
			Assert.That(result.ContentType, Is.EqualTo("application/javascript"));
		}
	}
}

