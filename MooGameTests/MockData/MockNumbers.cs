using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameTests.MockData
{
	internal class MockNumbers
	{
		public string RandomTestNum(int maxNumTest)
		{
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(maxNumTest);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(maxNumTest);
					randomDigit = "" + random;
				}
				//Om randomNummer inehåller samma Nummer som redan finns i Goal -> TestFail
				if (goal.Contains(randomDigit))
				{
					Assert.Fail();
				}
				goal = goal + randomDigit;
			}
			return goal;
		}
	}
}
