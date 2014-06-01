using System;
using NUnit.Framework;
using Nancy.Testing;
using Yose;
using HtmlAgilityPack;
using System.Xml;

namespace Tests
{
	[TestFixture]
	public class MinesweeperPage
	{
		private Browser browser;
		private BrowserResponse result;
		private HtmlDocument page;

		[SetUp]
		public void ThePage()
		{
			browser = new Browser(with => with.Module(new NancyRoutes()));
			result = browser.Get("/minesweeper", with =>  { with.HttpRequest(); });
			var content = result.Body.AsString ();
			page = new HtmlDocument();
			page.LoadHtml (content);
		}

		[Test]
		public void HasTheExpectedTitle()
		{
			Assert.That (page.GetElementbyId ("title").InnerText, Is.EqualTo ("Minesweeper"));
		}

		[Test]
		public void HasAGrid()
		{
			Assert.That (page.GetElementbyId ("grid"), Is.Not.Null);
		}
	}
}

