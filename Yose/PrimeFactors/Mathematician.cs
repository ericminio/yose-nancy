using System;
using System.Collections.Generic;

namespace Yose
{
	public class Mathematician
	{
		public List<int> PrimeFactorsOf(int number)
		{
			var factors = new List<int> ();

			var factor = 2;
			while (number % factor == 0) 
			{
				factors.Add (factor);
				number /= factor;
			}

			return factors;
		}
	}
}

