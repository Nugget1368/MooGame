using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame.Logistics;
using MooGameTests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Logistics.Tests
{
	[TestClass()]
	public class LogicTests
	{
		MockNumbers randomNum = new MockNumbers();
		// RandomTestNum(maxNumTest = 4)
		// --> Endast 0-3 kommer slumpas fram för att garantera att inga dubletter görs
		int maxNum = 4;
		[TestMethod()]
		public void makeGoalTest()
		{
			string goal = randomNum.RandomTestNum(maxNum);
			Console.WriteLine(goal);
			Assert.IsTrue(true);
		}

		[TestMethod()]
		public void CheckResultPassTest()
		{
			string goal = randomNum.RandomTestNum(maxNum);
			string result = "";
			string guess;
			//Du kan se att det krävdes flera omgångar för att det skulle bli rätt
			int numOfGuesses = 0;
			
			while(result != "BBBB,")
			{
				numOfGuesses++;
				guess = randomNum.RandomTestNum(maxNum);
				int cows = 0, bulls = 0;
				guess += "    ";     // if player entered less than 4 chars
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < 4; j++)
					{
						if (goal[i] == guess[j])
						{
							if (i == j)
							{
								bulls++;
							}
							else
							{
								cows++;
							}
						}
					}
				}
				result = "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
			}
			Console.WriteLine($"Result: {result} {numOfGuesses} guesses.");
			Assert.AreEqual("BBBB,", result);
		}

		[TestMethod()]
		public void CheckResultFailTest()
		{
			string goal = randomNum.RandomTestNum(maxNum);
			string result = "";
			string guess;
			//Du kan se att det krävdes flera omgångar för att det skulle bli rätt
			int numOfGuesses = 0;

			while (result != ",CCCC")
			{
				numOfGuesses++;
				guess = randomNum.RandomTestNum(maxNum);
				int cows = 0, bulls = 0;
				guess += "    ";     // if player entered less than 4 chars
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < 4; j++)
					{
						if (goal[i] == guess[j])
						{
							if (i == j)
							{
								bulls++;
							}
							else
							{
								cows++;
							}
						}
					}
				}
				result = "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
				//Se olika resultat
				Console.WriteLine(result);
			}
			Console.WriteLine($"Result: {result} {numOfGuesses} guesses.");
			Assert.AreEqual(",CCCC", result);
		}
	}
}