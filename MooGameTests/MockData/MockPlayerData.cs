using MooGame.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameTests.MockData
{
	internal class MockPlayerData : IPlayerData
	{
		public string Name { get; set; }

		public int NGames { get; set; }

		public int GuessTotal { get; set; }

		public string Guess { get; set; }

		public MockPlayerData() 
		{
			this.Name = "TestObject";
			NGames = 1;
			GuessTotal = 4;
			Guess = "TestGuess";
		}
		public MockPlayerData(string name, int guesses)
		{
			Name = name;
			NGames = 1;
			GuessTotal = guesses;
			Guess = "TestGuess";
		}

		public double PlayerScore(int totalGuesses, int numOfGames)
		{
			return (double)totalGuesses / numOfGames;
		}

		public void ResetGuessTotal()
		{
			GuessTotal = 0;
		}

		public void SetGuess(string guess)
		{
			GuessTotal++;
			this.Guess= guess;
		}

		public void SetName(string name)
		{
			this.Name= name;
		}

		public void Update(int guesses)
		{
			GuessTotal += guesses;
			NGames++;
		}
	}
}
