using System;
using NUnit.Framework;
using Nancy.Testing;
using Yose;
using HtmlAgilityPack;
using System.Xml;

namespace Tests
{
	[TestFixture]
	public class MinesweeperWorld
	{
		private Browser browser;
		private BrowserResponse result;

		[SetUp]
		public void MinesweeperModule()
		{
			browser = new Browser(with => with.Module(new NancyRoutes()));
			result = browser.Get("/minesweeper", with =>  { with.HttpRequest(); });
		}

		[Test]
		public void IsOnline ()
		{
			Assert.That(result.StatusCode, Is.EqualTo(Nancy.HttpStatusCode.OK));
		}

		[Test]
		public void HasATitle()
		{
			Assert.That(result.Body.AsString(), Is.StringContaining("id=\"title\""));
		}
	}
}

