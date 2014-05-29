using System;
using NUnit.Framework;
using Yose;
using System.Collections.Generic;

namespace Tests
{
	[TestFixture]
	public class MathematicianTest
	{
		[Test]
		public void CanDecompose2()
		{
			Assert.That (new Mathematician().PrimeFactorsOf(2), Is.EqualTo(new List<int> { 2 }));
		}

		[Test]
		public void CanDecompose4()
		{
			Assert.That (new Mathematician().PrimeFactorsOf(4), Is.EqualTo(new List<int> { 2, 2 }));
		}
	}
}

