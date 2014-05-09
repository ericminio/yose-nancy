using NUnit.Framework;
using Nancy.Testing;
using Nancy;
using System.Web.Script.Serialization;

namespace Tests
{
    [TestFixture]
    public class TddReadyTest
    {
        [Test]
        public void NUnitIsReady()
        {
            Assert.That(1 + 1, Is.EqualTo(2));
        }

		[TestFixture]
		public class NancyReadyTest
		{
			private Browser browser;

			[SetUp]
			public void MyReadyNancyModule()
			{
				browser = new Browser(with => with.Module(new MyReadyNancyModule()));
			}

			[Test]
			public void NancyIsready()
			{
				var result = browser.Get("/", with => { with.HttpRequest(); });

				Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
			}

			[Test]
			public void OneWayToAccessQueryString()
			{
				var result = browser.Get("/any?id=23", with => { with.HttpRequest(); });

				Assert.That(result.Body.AsString(), Is.EqualTo("23"));
			}

			[Test]
			public void OneWayToReturnJson()
			{
				browser = new Browser(with => with.Module(new MyJsonNancyModule()));
				var result = browser.Get("/anyJson?id=23", with => { with.HttpRequest(); });
				dynamic content = new JavaScriptSerializer ().Deserialize<dynamic>(result.Body.AsString());

				Assert.That(result.ContentType, Is.StringContaining("application/json"));
				Assert.That(result.Body.AsString(), Is.EqualTo("{\"id\":\"23\"}"));
				Assert.That(content["id"], Is.EqualTo("23"));
			}
		}
	}

	class MyReadyNancyModule : NancyModule
	{
		public MyReadyNancyModule()
		{
			Get["/"] = _ => "Hello World!";

			Get["/any?id={id}"] = parameters => { return parameters.id; };
		}
	}

	class MyJsonNancyModule : NancyModule
	{
		public MyJsonNancyModule()
		{
			Get["/anyJson?id={id}"] = parameters => Response.AsJson(new { id = parameters.id } ); 
		}
	}
}

