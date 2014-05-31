using System;
using NUnit.Framework;
using Nancy.Testing;
using Yose;

namespace Tests
{
	[TestFixture]
	public class MinesweeperWorld
	{
		private Browser browser;
		private BrowserResponse result;

		[SetUp]
		public void PrimeFactorsModule()
		{
			browser = new Browser(with => with.Module(new NancyRoutes()));
			result = browser.Get("/minesweeper", with =>  { with.HttpRequest(); });
		}

		[Test]
		public void IsOnline ()
		{
			Assert.That(result.StatusCode, Is.EqualTo(Nancy.HttpStatusCode.OK));
		}
	}
}

